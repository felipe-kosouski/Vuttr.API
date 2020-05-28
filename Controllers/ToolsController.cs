using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetTool(Guid id)
        {
            var tool = await _repository.Tool.GetToolAsync(id, trackChanges: false);
            if (tool == null)
            {
                _logger.LogInfo($"Tool with id: {id} does not exist in the database.");
                return NotFound();
            }
            else
            {
                var toolDto = _mapper.Map<ToolDto>(tool);
                return Ok(toolDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTool(ToolForCreationDto tool)
        {
            if (tool == null)
            {
                _logger.LogError("ToolForCreationDto object sent from client is null");
                return BadRequest("Tool object is null");
            }
            var toolEntity = _mapper.Map<Tool>(tool);
            _repository.Tool.CreateTool(toolEntity);
            await _repository.SaveAsync();

            var toolToReturn = _mapper.Map<ToolDto>(toolEntity);
            return CreatedAtRoute("ToolById", new {id = toolToReturn.Id}, toolToReturn);
        }
    }
}