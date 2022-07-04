using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Wallet;

public class WalletHistory
{
    public int Amonut { get; set; }
    public bool IsPositive { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
