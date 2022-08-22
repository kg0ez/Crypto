using Microsoft.EntityFrameworkCore;

namespace Crypto.Model.Models
{
	public class Ticker:BaseModel
	{
		public string Pair { get; set; } = null!;
		public long UpdatedAt { get; set; }
        [Precision(18, 6)]
		public decimal HighPrice { get; set; }
		[Precision(18, 6)]
		public decimal LowPrice { get; set; }
		[Precision(18,6)]
		public decimal ASK { get; set; }
		[Precision(18, 6)]
		public decimal BID { get; set; }

		public int ExchangeId { get; set; }
		public Exchange Exchange { get; set; }
	}
}

