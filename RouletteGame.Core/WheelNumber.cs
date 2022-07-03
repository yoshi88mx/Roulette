using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core;

public class WheelNumber
{
    public string Number { get; set; } = String.Empty;
    public WheelColor Color { get; set; }
    public bool IsOdd { get; set; }
}
