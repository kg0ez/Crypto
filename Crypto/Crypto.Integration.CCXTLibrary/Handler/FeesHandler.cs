using Crypto.Common.Dto;

namespace Crypto.Integration.CCXTLibrary.Handler
{
	public static class FeesHandler
	{
		public static FeeDto Get(string exchangeName)
		{
			var api = ApiHandler.GetExchange(exchangeName);

			var fees = api.publicClient.ExchangeInfo.Fees.trading;

			var taxDto = new FeeDto() { Maker = fees.maker, Taker = fees.taker };

			return taxDto;
		}

	}
}

