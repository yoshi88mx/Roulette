using RouletteGame.Core.Wallet;

namespace RouletteGame.Server.Services;

public class WalletService : IWallet, IWalletCustomer
{
    public int Total { get; private set; }
    private List<WalletHistory> History { get; set; }

    private readonly ILogger<WalletService> logger;
    public WalletService(ILogger<WalletService> logger)
    {
        Total = 0;
        History = new List<WalletHistory>();
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task AddMoney(int mount)
    {
        await Task.FromResult(Total += mount);
        History.Add(new WalletHistory { Amonut = mount, IsPositive = true });
        logger.LogInformation($"{nameof(AddMoney)} : {mount}");
    }

    public async Task<int> GetAvailable()
    {
        return await Task.FromResult(Total);
    }

    public async Task<List<WalletHistory>> GetHistory()
    {
        return await Task.FromResult(History);
    }

    public async Task RemoveMoney(int mount)
    {
        await Task.FromResult(Total -= mount);
        History.Add(new WalletHistory { Amonut = mount, IsPositive = false });
        logger.LogInformation($"{nameof(RemoveMoney)} : {mount}");
    }

    public async Task<bool> AddInitialMoney(int amonut)
    {
        if (!await CanAddInitialMoney())
        {
            return false;
        }
        await AddMoney(amonut);
        return true;
    }

    public async Task<bool> CanAddInitialMoney()
    {
        if (History.Any())
        {
            return await Task.FromResult(false);
        }
        return await Task.FromResult(true);
    }
}