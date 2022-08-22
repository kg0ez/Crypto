using AutoMapper;
using Crypto.Common.Dto;
using Crypto.Model.Models;

namespace Crypto.BusinesLogic.Mapper
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Exchange,ExchangeDto>().ReverseMap();
			CreateMap<Instrument,InstrumentDto>().ReverseMap();
			CreateMap<Ticker,TickerDto>().ReverseMap();
			CreateMap<Fee,FeeDto>().ReverseMap();
			CreateMap<ExchangeInfo, ExchangeInfoDto>().ReverseMap();
			CreateMap<TickerInfo, TickerInfoDto>().ReverseMap();
			CreateMap<TickerVolume, TickerVolumeDto>().ReverseMap();
		}
	}
}

