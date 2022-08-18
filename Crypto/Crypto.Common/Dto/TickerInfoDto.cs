namespace Crypto.Common.Dto
{
	public class TickerInfoDto
	{
		public string Couple { get; set; }
		public bool Deposit { get; set; }
		public bool Whithdrawal { get; set; }
		public bool Trade { get; set; }
		public int ExchangeId { get; set; }
	}
}

