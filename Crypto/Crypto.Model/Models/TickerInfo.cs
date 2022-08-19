namespace Crypto.Model.Models
{
	public class TickerInfo : BaseModel
	{
		public string Pair { get; set; } = null!;
		public bool Deposit { get; set; }
		public bool Whithdrawal { get; set; }
		public bool Trade { get; set; }

		public int ExchangeId { get; set; }
		public Exchange Exchange { get; set; }
	}
}

