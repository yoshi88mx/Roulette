using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Exceptions;
public class BetZeroException : Exception
{
    public BetZeroException(string messge) : base(messge)
    {

    }
}