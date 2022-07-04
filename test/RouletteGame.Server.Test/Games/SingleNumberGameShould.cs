using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RouletteGame.Core;
using RouletteGame.Core.Exceptions;
using RouletteGame.Core.Wallet;
using RouletteGame.Core.Wheel;
using RouletteGame.Server.Services;
using Xunit;

namespace RouletteGame.Server.Test.Games;
public class SingleNumberGameShould
{
    private readonly Mock<IWheel> _mockWhell;
    private readonly Mock<IWallet> _mockWallet;
    private readonly Mock<IWalletCustomer> _mockWalletCustomer;

    public SingleNumberGameShould()
    {
        _mockWhell = new Mock<IWheel>();
        _mockWallet = new Mock<IWallet>();
        _mockWalletCustomer = new Mock<IWalletCustomer>();
    }

    [Fact]
    public async void ThrowBetZeroExceptionWhenIsZero()
    {
        var game = new SingleNumberService(_mockWhell.Object, _mockWalletCustomer.Object, _mockWallet.Object);
        await Assert.ThrowsAsync<BetZeroException>(async () => await game.IsMyLuckyDay("2", 0));
    }

    [Fact]
    public async void ThrowNotEnoughMoneyException()
    {
        _mockWalletCustomer.Setup(t => t.GetAvailable()).Returns(Task.FromResult(5));
        _mockWhell.Setup(t => t.GetAllNumbers()).Returns(new List<WheelNumber>() { new WheelNumber { Color = WheelColor.Red, Number = "4", IsOdd = true } });
        var game = new SingleNumberService(_mockWhell.Object, _mockWalletCustomer.Object, _mockWallet.Object);
        await Assert.ThrowsAsync<NotEnoughMoneyException>(async () => await game.IsMyLuckyDay("4", 10));
    }

    [Fact]
    public async void LoseTheGame()
    {
        _mockWalletCustomer.Setup(t => t.GetAvailable()).Returns(Task.FromResult(10));
        _mockWhell.Setup(t => t.GiveMeANumber()).Returns(new WheelNumber { Color = WheelColor.Red, Number = "2", IsOdd = true });
        _mockWhell.Setup(t => t.GetAllNumbers()).Returns(new List<WheelNumber>() { new WheelNumber { Color = WheelColor.Red, Number = "5", IsOdd = true } });
        var game = new SingleNumberService(_mockWhell.Object, _mockWalletCustomer.Object, _mockWallet.Object);
        Assert.False(await game.IsMyLuckyDay("5", 10));
    }

    [Fact]
    public async void WinTheGame()
    {
        _mockWalletCustomer.Setup(t => t.GetAvailable()).Returns(Task.FromResult(10));
        _mockWhell.Setup(t => t.GiveMeANumber()).Returns(new WheelNumber { Color = WheelColor.Red, Number = "2" });
        _mockWhell.Setup(t => t.GetAllNumbers()).Returns(new List<WheelNumber>() { new WheelNumber { Color = WheelColor.Red, Number = "2", IsOdd = true } });
        var game = new SingleNumberService(_mockWhell.Object, _mockWalletCustomer.Object, _mockWallet.Object);
        Assert.True(await game.IsMyLuckyDay("2", 10));
    }
}