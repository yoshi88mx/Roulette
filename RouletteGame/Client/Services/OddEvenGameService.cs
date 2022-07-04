using System.Net.Http.Json;
using RouletteGame.Core.GamesContracts;

namespace RouletteGame.Client.Services;

public class OddEvenGameService : IOddEvenGame
{
    private readonly HttpClient _httpClient;

    public OddEvenGameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<bool> IsMyLuckyDay(string number, int bet)
    {
        return await _httpClient.GetFromJsonAsync<bool>($"games/evenodd?number={number}&bet={bet}");
    }
}
