using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SouthSeaTrader.Server.Data;
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

        ApplicationDbContext _db;

        public TradeDataController(ApplicationDbContext db)
        {
            _db = db;
        }

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
        public Trade TradeGoods()
        {
            var rng = new Random();

            var trade = _db.Trades
                .Include(e => e.Goods)
                .Where(e => string.IsNullOrEmpty(e.ShipName)).FirstOrDefault();

            if(trade == null)
            {
                trade = new Trade();
                _db.Trades.Add(trade);
                _db.SaveChanges();

                for (var i = 0; i < Enum.GetNames(typeof(Symbol)).Length; i++)
                {
                    var tradeGood = new TradeGood
                    {
                        Name = Goods[rng.Next(0, 5)],
                        Cost = Math.Round(rng.NextDouble() * 100, 2),
                        Instrument = (Symbol)rng.Next(0, 3),
                        Recommendation = Recommend[rng.Next(0, 3)],
                        TradeId = trade.TradeId,
                        Trade = trade
                    };
                    _db.TradeGoods.Add(tradeGood);
                    _db.SaveChanges();
                }
            }

            return trade;

        }

        [Authorize]
        [HttpPost]
        public Trade AddTradesToShip(int tradeId, List<TradeGood> tradeGoods)
        {

            var trade = new Trade { TradeDate = DateTime.Now, Goods = tradeGoods, Profit = 0.0, ShipName = "Winter" };
            _db.Trades.Add(trade);
            _db.SaveChanges();

            return trade;

        }
    }
}
