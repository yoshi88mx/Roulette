using Microsoft.AspNetCore.ResponseCompression;
using RouletteGame.Core;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Core.Wallet;
using RouletteGame.Core.Wheel;
using RouletteGame.Server.Middleware;
using RouletteGame.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IWheel, WheelService>();
builder.Services.AddSingleton<IOddEvenGame, EvenOddService>();
builder.Services.AddSingleton<IRedBlackGame, RedBackService>();
builder.Services.AddSingleton<IOneTwoTree, OneTwoTreeService>();
builder.Services.AddSingleton<ILowHighGame, LowHighService>();
builder.Services.AddSingleton<ISingleNumerGame, SingleNumberService>();
builder.Services.AddSingleton<IWallet, WalletService>();
builder.Services.AddSingleton<IWalletCustomer, WalletCustomerService>();
builder.Services.AddSingleton<IWalletHistoryCustomer, WalletHistoryCustomerService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHsts();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();