using System;
using System.Threading.Tasks;

namespace Vuttr.API.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChanges();
    }
}