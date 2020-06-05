using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Virtuality.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {

        public TeacherController()
        {

        }

    }
}