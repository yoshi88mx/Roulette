using System.Net.Http.Json;
using RouletteGame.Core.Wallet;
using RouletteGame.Shared;

namespace RouletteGame.Client.Services;

public class WalletService : IWalletCustomer, IWalletHistoryCustomer
{
    private readonly HttpClient _httpClient;

    public WalletService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task Add(WalletHistory history)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddInitialMoney(int amonut)
    {
        var can = await CanAddInitialMoney();
        if (can) await _httpClient.PostAsJsonAsync($"wallet?amount={amonut}", false);
        return can;
    }

    public async Task<bool> CanAddInitialMoney()
    {
        return await _httpClient.GetFromJsonAsync<bool>("wallet/canadd");
    }

    public async Task<int> GetAvailable()
    {
        return await _httpClient.GetFromJsonAsync<int>("wallet/balance");
    }

    public async Task<List<WalletHistoryDto>> GetHistory()
    {
        return await _httpClient.GetFromJsonAsync<List<WalletHistoryDto>>("wallet/balance") ?? new List<WalletHistoryDto>();
    }
}