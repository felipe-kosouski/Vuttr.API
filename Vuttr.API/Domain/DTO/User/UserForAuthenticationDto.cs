using System.ComponentModel.DataAnnotations;

namespace Vuttr.API.Domain.DTO.User
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; set; }
        
    }
}