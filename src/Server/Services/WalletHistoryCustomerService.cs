using AutoMapper;
using RouletteGame.Core.Wallet;
using RouletteGame.Shared;

namespace RouletteGame.Server.Services;

public class WalletHistoryCustomerService: IWalletHistoryCustomer
{
    private List<WalletHistory> History { get; set; }
    private readonly IMapper _mapper;

    public WalletHistoryCustomerService(IMapper mapper)
    {
        _mapper = mapper;
        History = new List<WalletHistory>();
    }

    public async Task<List<WalletHistoryDto>> GetHistory()
    {
        return await Task.FromResult(_mapper.Map<List<WalletHistoryDto>>(History));
    }

    public async Task Add(WalletHistory history)
    {
        History.Add(history);
        await Task.FromResult(true);
    }
}
