namespace Crypto.Model.Models
{
	public class TickerVolume:BaseModel
	{
		public string Pair { get; set; } = null!;
		public decimal BaseVolume { get; set; }
		public decimal QuoteVolume { get; set; }

		public int ExchangeId { get; set; }
		public Exchange Exchange { get; set; }
	}
}

