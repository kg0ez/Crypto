namespace Crypto.Common.Dto
{
	public class TickerDto
	{
		public string Pair { get; set; } = null!;
		public long UpdatedAt { get; set; }
		public decimal HighPrice { get; set; }
		public decimal LowPrice { get; set; }
		public decimal ASK { get; set; }
		public decimal BID { get; set; }
		public int ExchangeId { get; set; }
	}
}

