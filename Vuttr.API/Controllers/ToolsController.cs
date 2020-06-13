using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vuttr.API.ActionFilters;
using Vuttr.API.Domain.DTO.Tool;
using Vuttr.API.Domain.Models;
using Vuttr.API.Domain.Repository;
using Vuttr.API.Domain.RequestFeatures;
using Vuttr.API.LoggerService;

namespace Vuttr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IToolRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public ToolsController(IToolRepository repository, ILoggerManager logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Gets the List of all tools
        /// </summary>
        /// <param name="toolParameters"></param>
        /// <returns>The tools list</returns>
        /// <response code="200">Returns the list of tools</response>
        [HttpGet, Authorize]
        [ProducesResponseType(200)] 
        public async Task<IActionResult> GetTools([FromQuery] ToolParameters toolParameters)
        {
            var tools = await _repository.GetAllToolsAsync(toolParameters, false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(tools.MetaData));
            var toolsDto = _mapper.Map<IEnumerable<ToolDto>>(tools);
            return Ok(toolsDto);
        }
        
        /// <summary>
        /// Gets a tool
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The tool specified by the Id in request</returns>
        /// <response code="200">Returns the tool</response>
        /// <response code="404">If the tool was not found</response>
        [HttpGet("{id}", Name = "ToolById"), Authorize]
        [ProducesResponseType(200)] 
        [ProducesResponseType(404)] 
        [ServiceFilter(typeof(ValidateToolExistsAttribute))]
        public IActionResult GetTool(Guid id)
        {
            var tool = HttpContext.Items["tool"] as Tool;
            var toolDto = _mapper.Map<ToolDto>(tool);
            return Ok(toolDto);
        }

        /// <summary>
        /// Creates and save a tool
        /// </summary>
        /// <param name="tool"></param>
        /// <returns>The created tool</returns>
        /// <response code="201">Returns the newly created tool</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost, Authorize]
        [ProducesResponseType(201)] 
        [ProducesResponseType(400)] 
        [ProducesResponseType(422)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTool(ToolForCreationDto tool)
        {
            for (int i = 0; i < tool.Tags.Length; i++)
            {
                tool.Tags[i] = tool.Tags[i].ToLower();
            }
            var toolEntity = _mapper.Map<Tool>(tool);
            _repository.CreateTool(toolEntity);
            await _unitOfWork.SaveChanges();

            var toolToReturn = _mapper.Map<ToolDto>(toolEntity);
            return CreatedAtRoute("ToolById", new {id = toolToReturn.Id}, toolToReturn);
        }

        /// <summary>
        /// Updates a tool
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tool"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the tool was not found</response>
        [HttpPut("{id}"), Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateToolExistsAttribute))]
        public async Task<IActionResult> UpdateTool(Guid id, ToolForUpdateDto tool)
        {
            var existentTool = HttpContext.Items["tool"] as Tool;

            _mapper.Map(tool, existentTool);
            await _unitOfWork.SaveChanges();

            return NoContent();
        }
        
        /// <summary>
        /// Deletes a tool
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns no content</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="404">If the tool was not found</response>
        [HttpDelete("{id}"), Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateToolExistsAttribute))]
        public async Task<IActionResult> DeleteTool(Guid id)
        {
            var tool = HttpContext.Items["tool"] as Tool;
            
            _repository.DeleteTool(tool);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}