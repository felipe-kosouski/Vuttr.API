using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vuttr.API.Data.Context;
using Vuttr.API.Domain.Models;
using Vuttr.API.Domain.Repository;
using Vuttr.API.Domain.RequestFeatures;

namespace Vuttr.API.Data.Repository
{
    public class ToolRepository : RepositoryBase, IToolRepository
    {
        public ToolRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<PagedList<Tool>> GetAllToolsAsync(ToolParameters toolParameters, bool trackChanges)
        {
            List<Tool> tools;
            if (toolParameters.Tag != null)
            {
                tools = await (!trackChanges
                    ? _context.Tools.Where(tool => tool.Tags.Contains(toolParameters.Tag)).AsNoTracking()
                        .OrderBy(tool => tool.Title)
                        .ToListAsync()
                    : _context.Tools.Where(tool => tool.Tags.Contains(toolParameters.Tag)).OrderBy(tool => tool.Title)
                        .ToListAsync());
            }
            else
            {
                tools = await (!trackChanges
                    ? _context.Tools.OrderBy(tool => tool.Title).ToListAsync()
                    : _context.Tools.OrderBy(tool => tool.Title).ToListAsync());
            }
            return PagedList<Tool>.ToPagedList(tools, toolParameters.PageNumber, toolParameters.PageSize);
        }

        public async Task<Tool> GetToolAsync(Guid toolId, bool trackChanges)
        {
            return await (!trackChanges
                ? _context.Tools.AsNoTracking().FirstOrDefaultAsync(tool => tool.Id.Equals(toolId))
                : _context.Tools.FirstOrDefaultAsync(tool => tool.Id.Equals(toolId)));
        }

        public void CreateTool(Tool tool)
        {
            _context.Tools.AddAsync(tool);
        }

        public void DeleteTool(Tool tool)
        {
            _context.Tools.Remove(tool);
        }
    }
}