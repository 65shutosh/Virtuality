using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Virtuality.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        public UserController()
        {
          // Getting the user enrolled courses
          // 
          //  
        }

    }
}