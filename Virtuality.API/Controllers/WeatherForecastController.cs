﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Virtuality.API.Data;

namespace Virtuality.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public WeatherForecastController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        // private static readonly string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // private readonly ILogger<WeatherForecastController> _logger;

        // public WeatherForecastController(ILogger<WeatherForecastController> logger)
        // {
        //     _logger = logger;
        // }


//Synchronization is the way to design the thread-safe code where you can totally avoid the resource contention,
//make sure only one thread is accessing the resource at a time, and lead other threads waiting (blocked) for the 
//resource till the accessing thread releases the resource. 
//Synchronization neither means performing actions at the same time, nor one by one, 
//it just means design the code where it doesn’t cause a resource contention.

//By default these codes are Synchronous
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values =await  _dataContext.Values.ToListAsync();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public IActionResult GetValue(int id){
            var value = _dataContext.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     // to check how useDeveloperException works
        //    // throw new Exception("Exception Test :");
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

        [HttpGet("Ashutosh/{id}")]
        public string Get(int id)
        {
            return "Ashutosh " + id;
        }

        // Syntax to make sure they are not forgotten

           [HttpPost("{id}")]
           public IActionResult Post([FromBody] Object data){
               return Ok(data);
           }



        //   [HttpPut("{id}")]
        //   public string Put(int id, [FromBody] object data)
        //   {
        //       return "Put is Working " + data.ToString();
        //   }
    }
}
