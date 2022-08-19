using CCXT.NET.Shared.Coin.Public;
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
					Pair = ticker.marketId,
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

        public static async Task<List<TickerInfoDto>> GetTickersInfoAsync(List<string> firstInstruments,
            string secondInstrument, string exchangeName, int exchangeId)
        {
            var api = ApiHandler.GetExchange(exchangeName);

            var tickersInfoDto = new List<TickerInfoDto>();

            foreach (var firstInstrument in firstInstruments)
            {
				var market = await api.LoadMarketAsync($"{firstInstrument}/{secondInstrument}");

				var tickerInfoDto = new TickerInfoDto
				{
					Pair = ((market.result) as MarketItem).marketId,
					Deposit = ((market.result) as MarketItem).depositEnabled,
					Whithdrawal = ((market.result) as MarketItem).withdrawEnabled,
					Trade = market.result.active,
					ExchangeId = exchangeId
				};
				tickersInfoDto.Add(tickerInfoDto);
            }
			return tickersInfoDto;
        }

		public static async Task<List<TickerVolumeDto>> GetVolumesAsync(List<string> firstInstruments,
            string secondInstrument, string exchangeName, int exchangeId)
        {
            var api = ApiHandler.GetExchange(exchangeName);

            var volumesDto = new List<TickerVolumeDto>();

            foreach (var firstInstrument in firstInstruments)
            {
				var ticker = await api.FetchTickerAsync(firstInstrument, secondInstrument);

				var tickerVolumeDto = new TickerVolumeDto
				{
					Pair = ticker.marketId,
					BaseVolume = ticker.result.baseVolume,
					QuoteVolume = ticker.result.quoteVolume,
					ExchangeId = exchangeId
				};

				volumesDto.Add(tickerVolumeDto);
			}
			return volumesDto;
        }

	}
    
}

