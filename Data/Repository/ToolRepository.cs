using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vuttr.API.Data.Context;
using Vuttr.API.Domain.Models;
using Vuttr.API.Domain.Repository;

namespace Vuttr.API.Data.Repository
{
    public class ToolRepository : RepositoryBase<Tool>, IToolRepository
    {
        public ToolRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task< IEnumerable<Tool>> GetAllToolsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(tool => tool.Title).ToListAsync();
        }

        public async Task<Tool> GetToolAsync(Guid toolId, bool trackChanges)
        {
            return await FindByCondition(tool => tool.Id.Equals(toolId), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateTool(Tool tool)
        {
            Create(tool);
        }

        public void DeleteTool(Tool tool)
        {
            Update(tool);
        }
    }
}