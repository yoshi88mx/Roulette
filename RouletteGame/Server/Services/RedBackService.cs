using RouletteGame.Core;
using RouletteGame.Core.Exceptions;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Core.Wallet;

namespace RouletteGame.Server.Services
{
    public class RedBackService : IRedBlackGame
    {
        private readonly Wheel wheel;
        private readonly IWallet wallet;
        private readonly ILogger<RedBackService> logger;

        public RedBackService(Wheel wheel, IWallet wallet, ILogger<RedBackService> logger)
        {
            this.wheel = wheel ?? throw new ArgumentNullException(nameof(wheel));
            this.wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> IsMyLuckyDay(string color, int bet)
        {
            var moneyToSpent = await wallet.GetAvailable();
            if (bet <= moneyToSpent)
            {
                var result = wheel.GiveMeANumber();
                var colors = Enum.GetNames(typeof(WheelColor));
                if (colors.Any(t => t.ToLower() == color.ToLower()))
                {
                    WheelColor colorConvertion = (WheelColor)Enum.Parse(typeof(WheelColor), color, true);
                    var isLucky = result.Color == colorConvertion;
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
                else
                {
                    throw new ColorReferenceException($"Unsupported color: { color }");
                }
            }
            throw new NotEnoughMoneyException($"{nameof(NotEnoughMoneyException)}: Balance { await wallet.GetAvailable() }");
        }
    }
}
