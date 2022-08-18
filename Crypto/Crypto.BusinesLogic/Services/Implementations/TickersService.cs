using AutoMapper;
using Crypto.Integration.CCXTLibrary.Handler;
using Crypto.Model.Data;
using Crypto.Model.Models;

namespace Crypto.BusinesLogic.Services.Implementations
{
	public class TickersService
	{
		private ApplicationContext _context;
		private IMapper _mapper;

		public TickersService(IMapper mapper, ApplicationContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task Sync(string exchangeName,int exchangeId, List<string> firstInstruments,
			string secondInstrument = "USDT")
		{
			var tickersDto = await TickersHandler.GetTickersAsync(firstInstruments, secondInstrument,exchangeName, exchangeId);

			if (tickersDto == null)
				throw new Exception("Tickers not found");

			var tickers = _mapper.Map<List<Ticker>>(tickersDto);

			_context.Tickers.AddRange(tickers);
			_context.SaveChanges();
		}

		public async Task UpdateVolume(string exchangeName, int exchangeId, List<string> firstInstruments,
			string secondInstrument = "USDT")
		{
			var tickersInfoDto = await TickersHandler.GetTickersInfoAsync(firstInstruments, secondInstrument, exchangeName, exchangeId);

			var tickersInfo = _mapper.Map<List<TickerInfo>>(tickersInfoDto);

			_context.TickersInfo.AddRange(tickersInfo);
			_context.SaveChanges();
		}
	}
}

