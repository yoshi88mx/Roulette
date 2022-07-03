using System.Net.Http.Json;
using RouletteGame.Core.GamesContracts;

namespace RouletteGame.Client.Services;

public class RedBlackGameService : IRedBlackGame
{
    private readonly HttpClient httpClient;

    public RedBlackGameService(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<bool> IsMyLuckyDay(string color, int bet)
    {
        return await httpClient.GetFromJsonAsync<bool>($"games/redblack?color={color}&bet={bet}");
    }
}
