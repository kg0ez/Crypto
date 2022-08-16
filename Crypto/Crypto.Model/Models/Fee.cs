using Microsoft.EntityFrameworkCore;

namespace Crypto.Model.Models
{
	public class Fee
	{
		public int Id { get; set;}
		[Precision(18, 6)]
		public decimal Maker { get; set; }
		[Precision(18, 6)]
		public decimal Taker { get; set; }

		public int ExchangeId { get; set; }
		public Exchange Exchange { get; set; }
	}
}

