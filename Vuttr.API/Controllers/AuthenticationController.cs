using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vuttr.API.ActionFilters;
using Vuttr.API.Authentication;
using Vuttr.API.Domain.DTO.User;
using Vuttr.API.Domain.Models;
using Vuttr.API.LoggerService;

namespace Vuttr.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager; 
        private readonly IAuthenticationManager _authManager;
        public AuthenticationController (ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IAuthenticationManager authenticationManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authenticationManager;
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate(UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong username or Password");
                return Unauthorized();
            }

            var token = await _authManager.CreateToken();
            HttpContext.Response.Headers.Add("Authorization", token);
            return Ok("Logged in successfully");
        }
        
        
        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors) 
                {
                    ModelState.TryAddModelError(error.Code, error.Description); 
                }
                return BadRequest(ModelState);
            }
            
            return StatusCode(201);
        }
    }
}