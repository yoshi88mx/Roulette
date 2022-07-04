using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Wallet;
public interface IWalletCustomer
{
    Task<int> GetAvailable();
    Task<bool> AddInitialMoney(int amonut);
    Task<bool> CanAddInitialMoney();
}