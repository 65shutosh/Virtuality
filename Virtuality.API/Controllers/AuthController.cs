using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Virtuality.API.Data;
using Virtuality.API.Dtos;
using Virtuality.API.Models;
using System;

namespace Virtuality.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(/*[FormBody]*/UserForRegisterDto userForRegisterDto)
        {
            //validation of request is done at dto level

            // formbody and this code is required uin ubsence of ApiController
            // if( !ModelState.IsValid )
            // return BadRequest(ModelState);

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authRepository.UserExists(userForRegisterDto.Username))
                return BadRequest("Username Already Exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                email = userForRegisterDto.email
            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);

            //return CreatedAtRoute();
            return StatusCode(201);
        }


        // Login and Token Generation
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {

            //throw new Exception("Computer does't want to preocess your query");

            var userFromRepo = await _authRepository.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]{
            new Claim(ClaimTypes.NameIdentifier , userFromRepo.Id.ToString()),
            new Claim(ClaimTypes.Name , userFromRepo.Username),
            new Claim(ClaimTypes.Role , await _authRepository.IsTeacher(userFromRepo.Id) ? "Teacher" : "" )
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }

        [HttpPost("teacher/register")]
        public async Task<IActionResult> RegisterAsTeacher(Teacher teacher){
            if (! (await _authRepository.IsTeacher(teacher.UserId))){
            await _authRepository.RegisterAsTeacher(teacher);
            return StatusCode(201);
            }
            return BadRequest("User is already registered as a Teacher");
        }

        [HttpGet("teacher/{userId}")]
        public async Task<IActionResult> IsTeacher(int userId){
         return Ok(await _authRepository.IsTeacher(userId));
        }
    }
}