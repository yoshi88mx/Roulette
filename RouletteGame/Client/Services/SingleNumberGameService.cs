using System.Net.Http.Json;
using RouletteGame.Core.GamesContracts;

namespace RouletteGame.Client.Services;

public class SingleNumberGameService : ISingleNumerGame
{
    private readonly HttpClient _httpClient;

    public SingleNumberGameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<bool> IsMyLuckyDay(string number, int bet)
    {
        return await _httpClient.GetFromJsonAsync<bool>($"games/singlenumber?number={number}&bet={bet}");
    }
}
