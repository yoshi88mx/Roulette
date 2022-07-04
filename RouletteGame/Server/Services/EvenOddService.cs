using RouletteGame.Core;
using RouletteGame.Core.Exceptions;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Core.Wallet;
using RouletteGame.Core.Wheel;

namespace RouletteGame.Server.Services;

public class EvenOddService : IOddEvenGame
{
    private readonly IWheel _wheel;
    private readonly IWallet _wallet;
    private readonly IWalletCustomer _walletCustomer;

    public EvenOddService(IWheel wheel, IWallet wallet, IWalletCustomer walletCustomer)
    {
        _wheel = wheel ?? throw new ArgumentNullException(nameof(wheel));
        _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        _walletCustomer = walletCustomer ?? throw new ArgumentNullException(nameof(walletCustomer));
    }

    public async Task<bool> IsMyLuckyDay(bool isOdd, int bet)
    {
        if (bet <= 0) throw new BetZeroException($"{nameof(BetZeroException)}");
        if (bet <= await _walletCustomer.GetAvailable())
        {
            var result = _wheel.GiveMeANumber();
            var isLucky = result.IsOdd == isOdd;
            if (isLucky)
            {
                await _wallet.AddMoney(bet * 2);
            }
            else
            {
                await _wallet.RemoveMoney(bet);
            }
            return await Task.FromResult(isLucky);
        }
        throw new NotEnoughMoneyException($"{nameof(NotEnoughMoneyException)}: Balance { await _walletCustomer.GetAvailable() }");
    }
}
