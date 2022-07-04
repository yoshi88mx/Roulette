using RouletteGame.Core.Exceptions;
using RouletteGame.Core.Wallet;
using RouletteGame.Shared;

namespace RouletteGame.Server.Services;

public class WalletCustomerService : IWalletCustomer
{
    private readonly IWallet _wallet;
    private readonly IWalletHistoryCustomer _walletHistoryCustomer;

    public WalletCustomerService(IWallet wallet, IWalletHistoryCustomer walletHistoryCustomer)
    {
        _wallet = wallet;
        _walletHistoryCustomer = walletHistoryCustomer;
    }
    public async Task<bool> AddInitialMoney(int amonut)
    {
        if (amonut <= 0) throw new InitialValueWalletZeroException("You can not add 0 or less as initial value");
        if (!await CanAddInitialMoney())
        {
            return false;
        }
        await _wallet.AddMoney(amonut);
        return true;
    }

    public async Task<bool> CanAddInitialMoney()
    {
        var history = await _walletHistoryCustomer.GetHistory() ?? new List<WalletHistoryDto>();
        if (history.Any())
        {
            return await Task.FromResult(false);
        }
        return await Task.FromResult(true);
    }

    public async Task<int> GetAvailable()
    {
        await Task.FromResult(true);
        return _wallet.Total;
    }
}
