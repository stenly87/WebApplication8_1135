﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return posts;
        }

        static List<WeatherForecast> posts = new List<WeatherForecast>();
        static int autoincrement = 1;

        [HttpPost]
        public WeatherForecast Post(WeatherForecast value)
        {
            posts.Add(value);
            value.ID = autoincrement++;
            value.Summary += " readed";
            return value;
        }

        [HttpPut]
        public bool Put(WeatherForecast value)
        {
            var edit = posts.FirstOrDefault(f => f.ID == value.ID);
            if (edit == null)
                return false;

            var index = posts.IndexOf(edit);
            posts[index] = value;
            return true;
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(int id)
        {
            var send = posts.FirstOrDefault(f => f.ID == id);

            return send ?? new WeatherForecast();
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var delete = posts.FirstOrDefault(f => f.ID == id);
            if (delete == null)
                return false;
            posts.Remove(delete);
            return true;
        }
    }
}
