using Crypto.Common.Dto;

namespace Crypto.Integration.CCXTLibrary.Handler
{
    public static class ExchangesHandler
    {
        public static ExchangeDto GetData(string exchangeName)
        {
            var api = ApiHandler.GetExchange(exchangeName);

            var obj = api.publicClient;
            ExchangeDto exchangeDto = new ExchangeDto
            {
                Name = obj.DealerName,
                Jurisdiction = obj.ExchangeInfo.Countries[0]
            };

            return exchangeDto;
        }
    }

}

