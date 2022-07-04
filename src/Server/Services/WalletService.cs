using AutoMapper;
using RouletteGame.Core.Wallet;
using RouletteGame.Shared;

namespace RouletteGame.Server.Services;

public class WalletService : IWallet
{
    public int Total { get; set; }

    private readonly ILogger<WalletService> _logger;
    private readonly IMapper _mapper;
    private readonly IWalletHistoryCustomer _walletHistory;

    public WalletService(ILogger<WalletService> logger, IMapper mapper, IWalletHistoryCustomer walletHistory)
    {
        Total = 0;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper;
        _walletHistory = walletHistory;
    }

    public async Task AddMoney(int mount)
    {
        Total = Total + mount;
        await _walletHistory.Add(new WalletHistory { Amonut = mount, IsPositive = true });
        _logger.LogInformation($"{nameof(AddMoney)} : {mount}");
        await Task.FromResult(true);
    }

    public async Task RemoveMoney(int mount)
    {
        Total = Total - mount;
        await _walletHistory.Add(new WalletHistory { Amonut = mount, IsPositive = false });
        _logger.LogInformation($"{nameof(RemoveMoney)} : {mount}");
        await Task.FromResult(true);
    }

}