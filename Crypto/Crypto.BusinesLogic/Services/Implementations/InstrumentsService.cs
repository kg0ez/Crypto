using AutoMapper;
using Crypto.Integration.CCXTLibrary.Handler;
using Crypto.Model.Data;
using Crypto.Model.Models;

namespace Crypto.BusinesLogic.Services.Implementations
{
	public class InstrumentsService
	{
		private ApplicationContext _context;
		private IMapper _mapper;

		public InstrumentsService(IMapper mapper, ApplicationContext context)
        {
			_mapper = mapper;
			_context = context;
        }

		public async Task Sync(string exchangeName,int exchangeId)
        {
			var instrumentsDto = await InstrumentsHandler.GetMarketsAsync(exchangeName,exchangeId);

			var instruments = _mapper.Map<List<Instrument>>(instrumentsDto);

			_context.Instruments.AddRange(instruments);
			_context.SaveChanges();
        }

	}
}

