using Crypto.Common.Exchanges;

namespace Crypto.Integration.CCXTLibrary.Handler
{
	internal static class ApiHandler
	{
		public static CCXT.NET.Poloniex.Public.PublicApi GetExchange(string exchangeName)
		{
			switch (exchangeName)
			{
				case ExchangeNames.POLONIEX:
					return new CCXT.NET.Poloniex.Public.PublicApi();
				default:
					throw new Exception("Api not found");
			}
		}
	}
}

