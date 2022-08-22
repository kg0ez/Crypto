using Crypto.Common.Dto;

namespace Crypto.Integration.CCXTLibrary.Handler
{
	public static class InstrumentsHandler
	{
		public static async Task<List<InstrumentDto>> GetMarketsAsync(string exchangeName, int exchangeId)
		{
			var api = ApiHandler.GetExchange(exchangeName);

			var markets = await api.LoadMarketsAsync();

			var instrumentsDto = new List<InstrumentDto>();

			foreach (var coinName in markets.CoinNames)
			{
				var tool = new InstrumentDto { Name = coinName.Key, ExchangeId = exchangeId };
				instrumentsDto.Add(tool);
			}

			return instrumentsDto;
		}
	}
}

