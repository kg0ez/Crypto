using System;
namespace Crypto.Common.Dto
{
	public class TickerVolumeDto
	{
		public string Pair { get; set; }
		public decimal Amount { get; set; }
		public decimal Price { get; set; }
		public decimal Quantity { get; set; }
		public string ManipulationType { get; set; }
		public int ExchangeId { get; set; }
	}
}

