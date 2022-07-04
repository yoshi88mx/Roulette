using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Exceptions;

public class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException(string message) : base(message)
    {

    }
}