using RouletteGame.Core.Wallet;
using RouletteGame.Shared;
using System.Net.Http.Json;

namespace RouletteGame.Client.Services;

public class WalletHistoryService : IWalletHistoryCustomer
{
    private readonly HttpClient _httpClient;

    public WalletHistoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public Task Add(WalletHistory history)
    {
        throw new NotImplementedException();
    }

    public async Task<List<WalletHistoryDto>> GetHistory()
    {
        return await _httpClient.GetFromJsonAsync<List<WalletHistoryDto>>("wallet/history") ?? new List<WalletHistoryDto>();
    }
}
