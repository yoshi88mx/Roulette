using RouletteGame.Core;
using RouletteGame.Core.Exceptions;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Core.Wallet;

namespace RouletteGame.Server.Services;

public class RedBackService : IRedBlackGame
{
    private readonly Wheel _wheel;
    private readonly IWallet _wallet;
    private readonly IWalletCustomer _walletCustomer;

    public RedBackService(Wheel wheel, IWallet wallet, IWalletCustomer walletCustomer)
    {
        _wheel = wheel;
        _wallet = wallet;
        _walletCustomer = walletCustomer;
    }
    public async Task<bool> IsMyLuckyDay(string color, int bet)
    {
        var moneyToSpent = await _walletCustomer.GetAvailable();
        if (bet <= moneyToSpent)
        {
            var result = _wheel.GiveMeANumber();
            var colors = Enum.GetNames(typeof(WheelColor));
            if (colors.Any(t => t.ToLower() == color.ToLower()))
            {
                WheelColor colorConvertion = (WheelColor)Enum.Parse(typeof(WheelColor), color, true);
                var isLucky = result.Color == colorConvertion;
                if (isLucky)
                {
                    await _wallet.AddMoney(bet);
                }
                else
                {
                    await _wallet.RemoveMoney(bet);
                }
                return await Task.FromResult(isLucky);
            }
            else
            {
                throw new ColorReferenceException($"Unsupported color: { color }");
            }
        }
        throw new NotEnoughMoneyException($"{nameof(NotEnoughMoneyException)}: Balance { await _walletCustomer.GetAvailable() }");
    }
}
