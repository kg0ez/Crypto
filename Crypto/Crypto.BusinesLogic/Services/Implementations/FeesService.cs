using AutoMapper;
using Crypto.BusinesLogic.Services.Interface;
using Crypto.Integration.CCXTLibrary.Handler;
using Crypto.Model.Data;
using Crypto.Model.Models;

namespace Crypto.BusinesLogic.Services.Implementations
{
	public class FeesService: IFeesService
	{
		private ApplicationContext _context;
		public IMapper _mapper;

        public FeesService(ApplicationContext context, IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
        }

		public void Sync(string exchangeName, int exchangeId)
        {
			var feeDto = FeesHandler.Get(exchangeName);

            if (feeDto==null)
				throw new Exception("Fee not found");

			var fee = _mapper.Map<Fee>(feeDto);

			fee.ExchangeId = exchangeId;

			_context.Fees.Add(fee);
			_context.SaveChanges();
		}
	}
}

