using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteGame.Server.Services;
using Xunit;

namespace RouletteGame.Server.Test.Wheel;
public class WheelShould
{
    [Fact]
    public void GiveMeDiferentNumbers()
    {
        var wheel = new WheelService();

        var firstNumber = wheel.GiveMeANumber();
        var secondNumber = wheel.GiveMeANumber();

        Assert.NotSame(firstNumber, secondNumber);
    }

    [Fact]
    public void GiveMe38Numbers()
    {
        var wheel = new WheelService();

        var numbers = wheel.GetAllNumbers();

        Assert.True(numbers.Count == 38);
    }
}
