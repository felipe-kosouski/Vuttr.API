using System.Collections.Generic;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Domain.Repository
{
    public interface IToolRepository
    {
        IEnumerable<Tool> GetAllTools(bool trackChanges);
    }
}