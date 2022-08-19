using AutoMapper;
using Crypto.BusinesLogic.Mapper;
using Crypto.BusinesLogic.Services.Implementations;
using Crypto.BusinesLogic.Services.Interface;
using Crypto.Common.Exchanges;
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
    .AddLogging()
    .AddSingleton<IExchangesService,ExchangesService>()
    .AddSingleton<IFeesService,FeesService>()
    .AddSingleton<TickersService,TickersService>()
    .AddSingleton<InstrumentsService, InstrumentsService>()
    .AddDbContext<ApplicationContext>(opt=>opt.UseSqlServer("Server=localhost;Database=Crypto;User Id=sa;Password=Valuetech@123;"))
    .AddSingleton(mapper)
    .BuildServiceProvider();

var exchangeService = serviceCollection.GetService<IExchangesService>();
var feesService = serviceCollection.GetService<IFeesService>();

exchangeService.Create();

int exchangeId = exchangeService.GetId(ExchangeNames.POLONIEX);

//feesService.Sync(ExchangeNames.POLONIEX, exchangeId);

List<string> firstInstruments = new List<string> {"ETH", "GMT", "USDD", "DOGE", "BTC", "ETC","TRX","BNB","ETHS","ETHW","CULT"};

//List<string> firstTool = new List<string> { "GMT", "USDD", "DOGE", "BTC", "ETC","TRX","BNB","ETHS","ETHW","CULT",
//"BTT","LTC","DOT","XRP"};
var tickers = serviceCollection.GetService<TickersService>();

//var tickerTimer = new System.Timers.Timer();
//tickerTimer.Start();
//tickerTimer.Elapsed += async (o, e) =>
//{
//    tickerTimer.Interval = 1000;
//    Task.Run(async () =>
//    {
//        await tickers.Sync(ExchangeNames.POLONIEX, exchangeId, firstInstruments);
//        Console.WriteLine("Save tickers " + DateTime.Now);
//    });
//};

//var tickerInfoTimer = new System.Timers.Timer();
//tickerInfoTimer.Start();
//tickerInfoTimer.Elapsed += async (o, e) =>
//{
//    tickerInfoTimer.Interval = 600000;
//    Task.Run(async () =>
//    {
//        await tickers.UpdateOptions(ExchangeNames.POLONIEX, exchangeId, firstInstruments);
//        Console.WriteLine("Update options" + DateTime.Now);
//    });
//};

var tickerVolumeTimer = new System.Timers.Timer();
tickerVolumeTimer.Start();
tickerVolumeTimer.Elapsed += async (o, e) =>
{
    tickerVolumeTimer.Interval = 600000;
    Task.Run(async () =>
    {
        await tickers.UpdateVolume(ExchangeNames.POLONIEX, exchangeId, firstInstruments);
        Console.WriteLine("Update volumes " + DateTime.Now);
    });
};

//var instrumentsService = serviceCollection.GetService<InstrumentsService>();
//var instrumentTimer = new System.Timers.Timer();
//instrumentTimer.Start();
//instrumentTimer.Elapsed += async (o, e) =>
// {
//     instrumentTimer.Interval = 240000000;
//     await Task.Run(async () =>
//    {
//        await instrumentsService.Sync(ExchangeNames.POLONIEX, exchangeId);
//        System.Console.WriteLine("Save instrument");
//    });
// };


Console.ReadLine();
