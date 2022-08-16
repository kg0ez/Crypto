using AutoMapper;

namespace Crypto.BusinesLogic.Services.Interface
{
	public interface IFeesService
	{
		void Sync(string exchange, int exchangeId);
	}
}

