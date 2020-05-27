using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Domain.Repository
{
    public interface IToolRepository
    {
        Task<IEnumerable<Tool>> GetAllToolsAsync(bool trackChanges);
        Task<Tool> GetToolAsync(Guid toolId, bool trackChanges);
        void CreateTool(Tool tool);
        void DeleteTool(Tool tool);
    }
}