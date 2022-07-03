using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Exceptions;

public class ColorReferenceException : Exception
{
    public ColorReferenceException(string message) : base(message)
    {

    }
}
