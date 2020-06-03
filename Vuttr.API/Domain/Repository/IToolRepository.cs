using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vuttr.API.Domain.Models;
using Vuttr.API.Domain.RequestFeatures;

namespace Vuttr.API.Domain.Repository
{
    public interface IToolRepository
    {
        Task<PagedList<Tool>> GetAllToolsAsync(ToolParameters toolParameters, bool trackChanges);
        Task<Tool> GetToolAsync(Guid toolId, bool trackChanges);
        void CreateTool(Tool tool);
        void DeleteTool(Tool tool);
    }
}