using Crypto.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Crypto.Model.Data
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Exchange> Exchanges { get; set; } = null!;
		public DbSet<ExchangeInfo> ExchangeInfos { get; set; } = null!;
		public DbSet<Ticker> Tickers { get; set; } = null!;
		public DbSet<Instrument> Instruments { get; set; } = null!;
		public DbSet<Fee> Fees { get; set; } = null!;
		public DbSet<TickerInfo> TickersInfo { get; set; } = null!;
		public DbSet<TickerVolume> TickerVolumes { get; set; } = null!;
    }
}

