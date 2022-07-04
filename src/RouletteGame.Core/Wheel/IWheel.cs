using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.Wheel;
public interface IWheel
{
    WheelNumber GiveMeANumber();
    List<WheelNumber> GetAllNumbers();
}
