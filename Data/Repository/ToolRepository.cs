using System.Collections.Generic;
using System.Linq;
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
        
        public IEnumerable<Tool> GetAllTools(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(tool => tool.Title).ToList();
        }
    }
}