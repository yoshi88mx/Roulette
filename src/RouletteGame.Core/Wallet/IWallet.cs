using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Wallet;

public interface IWallet
{
    public int Total { get; set; }
    Task AddMoney(int mount);
    Task RemoveMoney(int mount);

}