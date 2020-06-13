using System.Threading.Tasks;
using Vuttr.API.Domain.DTO.User;

namespace Vuttr.API.Authentication
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}