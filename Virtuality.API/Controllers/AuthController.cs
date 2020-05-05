using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Virtuality.API.Data;
using Virtuality.API.Dtos;
using Virtuality.API.Models;

namespace Virtuality.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto){
            
            //validate request  
            // code required

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if( await _authRepository.UserExists(userForRegisterDto.Username)) 
                return BadRequest("Username Already Exists");

            var userToCreate = new User{
                Username = userForRegisterDto.Username 
            };

            var createdUser = await _authRepository.Register(userToCreate,userForRegisterDto.Password);

            //return CreatedAtRoute();
            return StatusCode(201);
        }
    }
}