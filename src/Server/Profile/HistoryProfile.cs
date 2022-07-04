using AutoMapper;
using RouletteGame.Core.Wallet;
using RouletteGame.Shared;

namespace RouletteGame.Server.Profile;

public class HistoryProfile : AutoMapper.Profile
{
    public HistoryProfile()
    {
        this.CreateMap<WalletHistory, WalletHistoryDto>();
    }
}