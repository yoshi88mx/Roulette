using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Exceptions;
public class InitialValueWalletZeroException: Exception
{
    public InitialValueWalletZeroException(string message):base(message)
    {

    }
}
