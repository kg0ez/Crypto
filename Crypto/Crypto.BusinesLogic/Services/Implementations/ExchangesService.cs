using AutoMapper;
using Crypto.BusinesLogic.Services.Interface;
using Crypto.Common.Dto;
using Crypto.Common.Exchanges;
using Crypto.Integration.CCXTLibrary.Handler;
using Crypto.Model.Data;
using Crypto.Model.Models;

namespace Crypto.BusinesLogic.Services.Implementations
{
    public class ExchangesService : IExchangesService
    {
        private ApplicationContext _context;
        private IMapper _mapper;

        public ExchangesService(ApplicationContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int GetId(string name)
        {
            var exchange = _context.Exchanges.FirstOrDefault(ex => ex.Name == name);

            if (exchange == null)
                throw new Exception($"Exchange with name {name} not found.");

            return exchange.Id;
        }

        public void Create()
        {
            ExchangeDto exchangeDto = ExchangesHandler.GetData(ExchangeNames.POLONIEX);

            if (exchangeDto == null)
                throw new Exception("Not found");

            var exchange = _mapper.Map<Exchange>(exchangeDto);

            _context.Exchanges.Add(exchange);
            _context.SaveChanges();
        }

        public void UpdateVolume(ExchangeInfoDto exchangeInfoDto,int id)
        {
            var exchangeInfo = _mapper.Map<ExchangeInfo>(exchangeInfoDto);

            exchangeInfo.ExchangeId = id;

            _context.ExchangeInfos.Add(exchangeInfo);
            _context.SaveChanges();
        }
    }
}

