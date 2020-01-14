using SouthSeaTrader.Shared.Enums;
using System;

namespace SouthSeaTrader.Shared
{
    public class TradeGood
    {
        public int TradeGoodId { get; set; }
        public string Name { get; set; }
        public string Recommendation { get; set; }
        public double Cost { get; set; }
        public Symbol Instrument { get; set; }

        public int TradeId { get; set; }
        public Trade Blog { get; set; }
    }
}
