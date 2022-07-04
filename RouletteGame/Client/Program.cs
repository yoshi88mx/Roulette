using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RouletteGame.Client;
using RouletteGame.Client.Services;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Core.Wallet;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}api/v1/") });
builder.Services.AddScoped<IRedBlackGame, RedBlackGameService>();
builder.Services.AddScoped<IOddEvenGame, OddEvenGameService>();
builder.Services.AddScoped<IWalletCustomer, WalletService>();
builder.Services.AddScoped<IWalletHistoryCustomer, WalletHistoryService>();
builder.Services.AddScoped<ISingleNumerGame, SingleNumberGameService>();



await builder.Build().RunAsync();