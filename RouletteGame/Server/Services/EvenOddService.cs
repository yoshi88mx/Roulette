using RouletteGame.Core;
using RouletteGame.Core.Exceptions;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Core.Wallet;

namespace RouletteGame.Server.Services;

public class EvenOddService : IOddEvenGame
{
    private readonly Wheel _wheel;
    private readonly IWallet _wallet;
    private readonly IWalletCustomer _walletCustomer;

    public EvenOddService(Wheel wheel, IWallet wallet, IWalletCustomer walletCustomer)
    {
        _wheel = wheel ?? throw new ArgumentNullException(nameof(wheel));
        _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        _walletCustomer = walletCustomer ?? throw new ArgumentNullException(nameof(walletCustomer));
    }

    public async Task<bool> IsMyLuckyDay(string number, int bet)
    {
        var canPlay = _wheel.Numbers.Any(t => t.Number == number);
        if (canPlay)
        {
            if (bet <= await _walletCustomer.GetAvailable())
            {
                var result = _wheel.GiveMeANumber();
                var isLucky = result.Number == number;
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
            throw new NotEnoughMoneyException($"{nameof(NotEnoughMoneyException)}: Balance { await _walletCustomer.GetAvailable() }");
        }
        throw new IsNotANumberAllowedException($"{nameof(IsNotANumberAllowedException)}: {number}");
    }
}
