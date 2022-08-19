using System;
using Microsoft.EntityFrameworkCore;

namespace Crypto.Model.Models
{
	public class TickerVolume:BaseModel
	{
		public string Pair { get; set; } = null!;
		[Precision(18, 6)]
		public decimal Amount { get; set; }
		[Precision(18, 6)]
		public decimal Price { get; set; }
		[Precision(18, 4)]
		public decimal Quantity { get; set; }
		public string ManipulationType { get; set; } = null!;

		public int ExchangeId { get; set; }
		public Exchange Exchange { get; set; }
	}
}

