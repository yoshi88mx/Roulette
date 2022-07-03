using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Common;

public interface ISpinTheWheel
{
    WheelNumber GiveMeANumber();
}
