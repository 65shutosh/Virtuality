using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Virtuality.API.Data;
using System.Net.Http;
using Virtuality.API.Helpers;
using System.IO;

namespace Virtuality.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public VideoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        //Synchronization is the way to design the thread-safe code where you can totally avoid the resource contention,
        //make sure only one thread is accessing the resource at a time, and lead other threads waiting (blocked) for the 
        //resource till the accessing thread releases the resource. 
        //Synchronization neither means performing actions at the same time, nor one by one, 
        //it just means design the code where it doesn’t cause a resource contention.

        //By default these codes are Synchronous
        // [HttpGet]
        // public async Task<IActionResult> GetValues()
        // {
        //     var values = await _dataContext.Values.ToListAsync();
        //     return Ok(values);
        // }

        // [AllowAnonymous]
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetValue(int id)
        // {
        //     var value = await _dataContext.Values.FirstOrDefaultAsync(x => x.Id == id);
        //     return Ok(value);
        // }

        // Using PhysicalFileResult
        [HttpGet("data/{filename}")]
        public PhysicalFileResult Get(string filename)
        {
            // var video = new VideoStream(filename);
            // var response =new HttpResponseMessage();
            //response.Content = new HttpResponseMessa () 
            var filePath = @"C:\video\" + filename + ".mp4";

            return PhysicalFile(filePath, "application/octet-stream", enableRangeProcessing: true);
        }

        // Using FileStramResult
        // [HttpGet("datav/{filename}")]
        // public FileStreamResult GetVideo(string filename)
        // {
        //     var _MIMETYPE = "video/mp4" ;
        //     FileStreamResult fileStreamResult = null ;
        //     var filePath = @"C:\video\" + filename + ".mp4";
        //     try
        //     {
        //     using ( FileStream fileStream = System.IO.File.Open(filePath , FileMode.Open , FileAccess.Read)){
        //         fileStreamResult = new FileStreamResult(fileStream , _MIMETYPE);
        //     }    
        //     }
        //     catch (System.Exception)
        //     {
        //         Console.WriteLine("Exception In GetVideo methood of VideoController");
        //     }

        // return fileStreamResult;
        // }
        // Syntax to make sure they are not forgotten

        //    [HttpPost("{id}")]
        //    public IActionResult Post([FromBody] Object data){
        //        return Ok(data);
        //    }





        //   [HttpPut("{id}")]
        //   public string Put(int id, [FromBody] object data)
        //   {
        //       return "Put is Working " + data.ToString();
        //   }
    }
}
