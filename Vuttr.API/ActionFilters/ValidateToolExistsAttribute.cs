using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vuttr.API.Domain.Repository;
using Vuttr.API.LoggerService;

namespace Vuttr.API.ActionFilters
{
    public class ValidateToolExistsAttribute : IAsyncActionFilter
    {
        private readonly IToolRepository _repository;
        private readonly ILoggerManager _logger;

        public ValidateToolExistsAttribute(IToolRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT") ? true : false;
            var id = (Guid)context.ActionArguments["id"];
            var tool = await _repository.GetToolAsync(id, trackChanges);
            if (tool == null) 
            {
                _logger.LogInfo($"Tool with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult(); 
            }
            else
            {
                context.HttpContext.Items.Add("tool", tool); await next();
            }
        }
    }
}