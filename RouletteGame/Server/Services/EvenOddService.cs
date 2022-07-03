using RouletteGame.Core;
using RouletteGame.Core.Exceptions;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Core.Wallet;

namespace RouletteGame.Server.Services
{
    public class EvenOddService : IOddEvenGame
    {
        private readonly Wheel wheel;
        private readonly IWallet wallet;

        public EvenOddService(Wheel wheel, IWallet wallet)
        {
            this.wheel = wheel ?? throw new ArgumentNullException(nameof(wheel));
            this.wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        }

        public async Task<bool> IsMyLuckyDay(string number, int bet)
        {
            var canPlay = wheel.Numbers.Any(t => t.Number == number);
            if (canPlay)
            {
                if (bet <= await wallet.GetAvailable())
                {
                    var result = wheel.GiveMeANumber();
                    var isLucky = result.Number == number;
                    if (isLucky)
                    {
                        await wallet.AddMoney(bet);
                    }
                    else
                    {
                        await wallet.RemoveMoney(bet);
                    }
                    return await Task.FromResult(isLucky);
                }
                throw new NotEnoughMoneyException($"{nameof(NotEnoughMoneyException)}: Balance { await wallet.GetAvailable() }");
            }
            throw new IsNotANumberAllowedException($"{nameof(IsNotANumberAllowedException)}: {number}");
        }
    }
}
