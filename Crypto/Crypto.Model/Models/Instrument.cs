namespace Crypto.Model.Models
{
	public class Instrument:BaseModel
	{
		public string Name { get; set; }

		public int ExchangeId { get; set; }
		public Exchange Exchange { get; set; }
	}
}

