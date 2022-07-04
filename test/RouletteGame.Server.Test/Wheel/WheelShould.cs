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

    [Fact]
    public void GiveMe2Zeros()
    {
        var wheel = new WheelService();

        var numbers = wheel.GetAllNumbers();

        var singleZero = numbers.Any(t => t.Number == "0");
        var doubleZero = numbers.Any(t => t.Number == "00");

        Assert.True(singleZero & doubleZero);
    }

    [Fact]
    public void BeGreenSingleZero()
    {
        var wheel = new WheelService();

        var numbers = wheel.GetAllNumbers();

        var singleZero = numbers.FirstOrDefault(t => t.Number == "0");

        Assert.True(singleZero.Color == Core.WheelColor.Green);
    }

    [Fact]
    public void BeGreenDoubleZero()
    {
        var wheel = new WheelService();

        var numbers = wheel.GetAllNumbers();

        var doubleZero = numbers.FirstOrDefault(t => t.Number == "00");

        Assert.True(doubleZero.Color == Core.WheelColor.Green);
    }

    [Fact]
    public void BeBlackAllOddNumbers()
    {
        var wheel = new WheelService();

        var numbers = wheel.GetAllNumbers();

        var odds = numbers.Where(t => t.IsOdd);

        Assert.True(odds.All(t => t.Color == Core.WheelColor.Black));
    }
}