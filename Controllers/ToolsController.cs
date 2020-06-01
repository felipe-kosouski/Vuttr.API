using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vuttr.API.ActionFilters;
using Vuttr.API.Domain.DTO.Tool;
using Vuttr.API.Domain.Models;
using Vuttr.API.Domain.Repository;
using Vuttr.API.LoggerService;

namespace Vuttr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        
        public ToolsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTools()
        {
            var tools = await _repository.Tool.GetAllToolsAsync(trackChanges: false);
            var toolsDto = _mapper.Map<IEnumerable<ToolDto>>(tools);
            return Ok(toolsDto);
        }

        [HttpGet("{id}", Name = "ToolById")]
        [ServiceFilter(typeof(ValidateToolExistsAttribute))]
        public  IActionResult GetTool(Guid id)
        {
            var tool = HttpContext.Items["tool"] as Tool;
            var toolDto = _mapper.Map<ToolDto>(tool);
            return Ok(toolDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTool(ToolForCreationDto tool)
        {
            var toolEntity = _mapper.Map<Tool>(tool);
            _repository.Tool.CreateTool(toolEntity);
            await _repository.SaveAsync();

            var toolToReturn = _mapper.Map<ToolDto>(toolEntity);
            return CreatedAtRoute("ToolById", new {id = toolToReturn.Id}, toolToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateToolExistsAttribute))]
        public async Task<IActionResult> UpdateTool(Guid id, ToolForUpdateDto tool)
        {
            var existentTool = HttpContext.Items["tool"] as Tool;

            _mapper.Map(tool, existentTool);
            await _repository.SaveAsync();

            return NoContent();
        }
        

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateToolExistsAttribute))]
        public async Task<IActionResult> DeleteTool(Guid id)
        {
            var tool = HttpContext.Items["tool"] as Tool;
            
            _repository.Tool.DeleteTool(tool);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}