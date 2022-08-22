namespace Crypto.Model.Models
{
	public class ExchangeInfo:BaseModel
	{
		public decimal VolumeUSD { get; set; }
		public decimal VolumeBTC { get; set; }

		public int ExchangeId { get; set; }
		public Exchange Exchange { get; set; }
	}
}

