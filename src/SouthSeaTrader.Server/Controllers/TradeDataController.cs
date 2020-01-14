using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SouthSeaTrader.Shared;
using SouthSeaTrader.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SouthSeaTrader.Server.Controllers
{
    [Route("api/[controller]")]
    public class TradeDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static string[] Goods = new[]
        {
            "Apples", "Bannas", "Coffee", "Rum", "Silk"
        };

        private static string[] Recommend = new[]
        {
            "Looks Great, buy some.", "Offload it at the next port.", "Put it in the warehouse."
        };

        [Authorize]
        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [Authorize]
        [HttpGet("[action]")]
        public IEnumerable<TradeGood> TradeGoods()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new TradeGood
            {
                Name = Goods[rng.Next(0, 5)],
                Cost = Math.Round(rng.NextDouble() * 100, 2),
                Instrument = (Symbol)rng.Next(0,3),
                Recommendation = Recommend[rng.Next(0, 3)]
            });
        }
    }
}
