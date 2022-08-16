using Crypto.Common.Dto;

namespace Crypto.Integration.CCXTLibrary.Handler
{
	public static class TickersHandler
	{
		public static async Task<List<TickerDto>> GetTickersAsync(List<string> firstInstruments,
			string secondInstrument, string exchangeName, int exchangeId)
		{
			var api = ApiHandler.GetExchange(exchangeName);

			var tickersDto = new List<TickerDto>();

			foreach (var firstInstrument in firstInstruments)
			{
				var ticker = await api.FetchTickerAsync(firstInstrument, secondInstrument);

				var model = new TickerDto
				{
					Couple = ticker.marketId,
					UpdatedAt = ticker.result.timestamp,
					HighPrice = ticker.result.highPrice,
					LowPrice = ticker.result.lowPrice,
					ASK = ticker.result.askPrice,
					BID = ticker.result.bidPrice,
					ExchangeId = exchangeId
				};
				tickersDto.Add(model);
			}
			return tickersDto;
		}
	}
    
}

