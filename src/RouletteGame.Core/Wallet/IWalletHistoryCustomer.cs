using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteGame.Shared;

namespace RouletteGame.Core.Wallet;
public interface IWalletHistoryCustomer
{
    Task<List<WalletHistoryDto>> GetHistory();
    Task Add(WalletHistory history);
}
