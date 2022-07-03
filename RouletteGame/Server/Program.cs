using Microsoft.AspNetCore.ResponseCompression;
using RouletteGame.Core;
using RouletteGame.Core.Wallet;
using RouletteGame.Server.Middleware;
using RouletteGame.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<Wheel>();
builder.Services.AddSingleton<EvenOddService>();
builder.Services.AddSingleton<RedBackService>();
builder.Services.AddSingleton<IWallet, WalletService>();
builder.Services.AddSingleton<IWalletCustomer, WalletService>();
builder.Services.AddControllersWithViews();
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


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();