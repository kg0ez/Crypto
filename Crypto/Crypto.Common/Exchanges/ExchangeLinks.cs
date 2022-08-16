namespace Crypto.Common.Exchanges
{
	public static class ExchangeLinks
	{
		public static string Get(string exchange)
		{
			switch (exchange)
			{
				case ExchangeNames.POLONIEX:
					return "https://cryptorank.io/ru/exchanges/poloniex";
				default:
					return null;
			}
		}
	}
}

