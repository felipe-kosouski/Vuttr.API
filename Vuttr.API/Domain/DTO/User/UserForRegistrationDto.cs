using System.ComponentModel.DataAnnotations;

namespace Vuttr.API.Domain.DTO.User
{
    public class UserForRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        
        [Required(ErrorMessage = "Username is required")] 
        public string UserName { get; set; } 
        
        [Required(ErrorMessage = "Password is required")] 
        public string Password { get; set; }
        public string Email { get; set; }
    }
}