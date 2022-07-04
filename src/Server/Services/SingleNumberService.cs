using RouletteGame.Core;
using RouletteGame.Core.Exceptions;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Core.Wallet;
using RouletteGame.Core.Wheel;

namespace RouletteGame.Server.Services;

public class SingleNumberService : ISingleNumerGame
{
    private readonly IWheel _wheel;
    private readonly IWalletCustomer _walletCustomer;
    private readonly IWallet _wallet;

    public SingleNumberService(IWheel wheel, IWalletCustomer walletCustomer, IWallet wallet)
    {
        _wheel = wheel;
        _walletCustomer = walletCustomer;
        _wallet = wallet;
    }
    public async Task<bool> IsMyLuckyDay(string number, int bet)
    {
        if (bet <= 0) throw new BetZeroException($"{nameof(BetZeroException)}");
        var canPlay = _wheel.GetAllNumbers().Any(t => t.Number == number);
        if (canPlay)
        {
            if (bet <= await _walletCustomer.GetAvailable())
            {
                var result = _wheel.GiveMeANumber();
                var isLucky = result.Number == number;
                if (isLucky)
                {
                    await _wallet.AddMoney(bet * Convert.ToInt32(number));
                }
                else
                {
                    await _wallet.RemoveMoney(bet);
                }
                return await Task.FromResult(isLucky);
            }
            throw new NotEnoughMoneyException($"{nameof(NotEnoughMoneyException)}: Balance { await _walletCustomer.GetAvailable() }");
        }
        throw new IsNotANumberAllowedException($"{nameof(IsNotANumberAllowedException)}: {number}");
    }
}