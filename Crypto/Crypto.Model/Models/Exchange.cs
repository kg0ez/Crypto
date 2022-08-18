namespace Crypto.Model.Models
{
	public class Exchange
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Jurisdiction { get; set; } = null!;

		public List<ExchangeInfo> ExchangeInfos { get; set; }

		public List<Instrument> Tools { get; set; }

		public List<Ticker> Tickers { get; set; }

		public List<TickerInfo> TickersInfo { get; set; }
	}
}

