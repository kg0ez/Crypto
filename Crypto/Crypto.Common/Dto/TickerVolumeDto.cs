namespace Crypto.Common.Dto
{
	public class TickerVolumeDto
	{
		public string Pair { get; set; }
		public decimal BaseVolume { get; set; }
		public decimal QuoteVolume { get; set; }
		public int ExchangeId { get; set; }
	}
}

