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

		public async Task Sync(string exchange,int exchangeId, List<string> firstInstruments,
			string secondInstrument = "USDT")
		{
			var tickersDto = await TickersHandler.GetTickersAsync(firstInstruments, secondInstrument,exchange, exchangeId);

			if (tickersDto == null)
				throw new Exception("Tickers not found");

			var tickers = _mapper.Map<List<Ticker>>(tickersDto);

			_context.Tickers.AddRange(tickers);
			_context.SaveChanges();
		}
	}
}

