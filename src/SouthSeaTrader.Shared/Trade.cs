using System;
using System.Collections.Generic;

namespace SouthSeaTrader.Shared
{
    public class Trade
    {
        public int TradeId { get; set; }
        public string ShipName { get; set; }
        public DateTime TradeDate { get; set; }
        public List<TradeGood> Goods { get; set; }
        public double Profit { get; set; }
    }
}
