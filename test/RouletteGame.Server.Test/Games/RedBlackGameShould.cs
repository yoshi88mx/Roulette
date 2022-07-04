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
public class RedBlackGameShould
{
    private readonly Mock<IWheel> _mockWhell;
    private readonly Mock<IWallet> _mockWallet;
    private readonly Mock<IWalletCustomer> _mockWalletCustomer;

    public RedBlackGameShould()
    {
        _mockWhell = new Mock<IWheel>();
        _mockWallet = new Mock<IWallet>();
        _mockWalletCustomer = new Mock<IWalletCustomer>();
    }

    [Fact]
    public async void ThrowBetZeroExceptionWhenIsZero()
    {
        var game = new RedBackService(_mockWhell.Object, _mockWallet.Object, _mockWalletCustomer.Object);
        await Assert.ThrowsAsync<BetZeroException>(async () => await game.IsMyLuckyDay("", 0));
    }

    [Fact]
    public async void ThrowNotEnoughMoneyException()
    {
        var game = new RedBackService(_mockWhell.Object, _mockWallet.Object, _mockWalletCustomer.Object);
        await Assert.ThrowsAsync<NotEnoughMoneyException>(async () => await game.IsMyLuckyDay("2", 10));
    }

    [Fact]
    public async void ThrowColorReferenceException()
    {
        _mockWalletCustomer.Setup(t => t.GetAvailable()).Returns(Task.FromResult(10));
        var game = new RedBackService(_mockWhell.Object, _mockWallet.Object, _mockWalletCustomer.Object);
        await Assert.ThrowsAsync<ColorReferenceException>(async () => await game.IsMyLuckyDay("notAnumber", 10));
    }

    [Fact]
    public async void LoseTheGame()
    {
        _mockWalletCustomer.Setup(t => t.GetAvailable()).Returns(Task.FromResult(10));
        _mockWhell.Setup(t => t.GiveMeANumber()).Returns(new WheelNumber { Color = WheelColor.Red, Number = "2" });
        var game = new RedBackService(_mockWhell.Object, _mockWallet.Object, _mockWalletCustomer.Object);
        Assert.False(await game.IsMyLuckyDay("Black", 10));
    }

    [Fact]
    public async void WinTheGame()
    {
        _mockWalletCustomer.Setup(t => t.GetAvailable()).Returns(Task.FromResult(10));
        _mockWhell.Setup(t => t.GiveMeANumber()).Returns(new WheelNumber { Color = WheelColor.Red, Number = "2" });
        var game = new RedBackService(_mockWhell.Object, _mockWallet.Object, _mockWalletCustomer.Object);
        Assert.True(await game.IsMyLuckyDay("Red", 10));
    }
}