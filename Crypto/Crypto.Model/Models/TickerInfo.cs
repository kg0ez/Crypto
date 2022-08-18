namespace Crypto.Model.Models
{
	public class TickerInfo : BaseModel
	{
		public string Couple { get; set; }
		public bool Deposit { get; set; }
		public bool Whithdrawal { get; set; }
		public bool Trade { get; set; }

		public int ExchangeId { get; set; }
		public Exchange Exchange { get; set; }
	}
}

