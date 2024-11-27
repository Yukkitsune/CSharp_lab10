using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketContext
{
    public class MarketContext : DbContext
    {
        public DbSet<Ticker> Tickers => Set<Ticker>();
        public DbSet<Price> Prices => Set<Price>();
        public DbSet<TodaysCondition> todaysConditions => Set<TodaysCondition>();
        public MarketContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MarketDB;User Id=sa;Password=Ha79197742105;");
        }
    }
}
