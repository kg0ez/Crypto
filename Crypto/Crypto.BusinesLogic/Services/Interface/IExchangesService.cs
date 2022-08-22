using AutoMapper;
using Crypto.Common.Dto;

namespace Crypto.BusinesLogic.Services.Interface
{
	public interface IExchangesService
	{
		int GetId(string name);
		void Create();
		void UpdateVolume(ExchangeInfoDto exchangeInfoDto, int id);
	}
}

