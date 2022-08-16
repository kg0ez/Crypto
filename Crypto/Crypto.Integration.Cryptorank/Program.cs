using AutoMapper;
using Crypto.BusinesLogic.Mapper;
using Crypto.BusinesLogic.Services.Implementations;
using Crypto.BusinesLogic.Services.Interface;
using Crypto.Common.Exchanges;
using Crypto.Integration.Cryptorank;
using Crypto.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var mapperConfiguration = new MapperConfiguration(x =>
{
    x.AddProfile<MappingProfile>();
});
mapperConfiguration.AssertConfigurationIsValid();

IMapper mapper = mapperConfiguration.CreateMapper();

var serviceCollection = new ServiceCollection()
    .AddSingleton<IExchangesService, ExchangesService>()
    .AddSingleton<Cryptorank, Cryptorank>()
    .AddDbContext<ApplicationContext>(opt => opt.UseSqlServer("Server=localhost;Database=Crypto;User Id=sa;Password=Valuetech@123;"))
    .AddSingleton(mapper)
    .BuildServiceProvider();
    
var cryptorank = serviceCollection.GetService<Cryptorank>();
var exchangeService = serviceCollection.GetService<IExchangesService>();

int exchangeId = exchangeService.GetId(ExchangeNames.POLONIEX);

var exchangeTimer = new System.Timers.Timer();
exchangeTimer.Start();
exchangeTimer.Elapsed += async (o, e) =>
{
    exchangeTimer.Interval = 200000;
    Task.Run(async () =>
    {
        var exchangeInfoDto = cryptorank.GetVolume(ExchangeNames.POLONIEX);
        exchangeService.UpdateVolume(exchangeInfoDto, exchangeId);
        Console.WriteLine("Delay two min " + DateTime.Now);
    });
};

Console.ReadLine();
