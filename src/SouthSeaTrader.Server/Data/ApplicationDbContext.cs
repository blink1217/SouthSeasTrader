using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SouthSeaTrader.Shared;

namespace SouthSeaTrader.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<TradeGood> TradeGoods { get; set; }
    }
}
