using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using RouletteGame.Core.Exceptions;
using RouletteGame.Core.Wallet;
using RouletteGame.Server.Profile;
using RouletteGame.Server.Services;
using RouletteGame.Shared;
using Xunit;

namespace RouletteGame.Server.Test.Wallet;
public class WalletCustomerShould
{
    private readonly WalletService _mockWallet;
    private readonly WalletHistoryCustomerService _mockWalletHistory;

    public WalletCustomerShould()
    {
        var mockLogger = new Mock<ILogger<WalletService>>();
        var myProfile = new HistoryProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);
        _mockWalletHistory = new WalletHistoryCustomerService(mapper);
        _mockWallet = new WalletService(mockLogger.Object, mapper, _mockWalletHistory);

    }

    [Theory]
    [InlineData(100)]
    [InlineData(1)]
    [InlineData(99999)]
    public async void CanAddInitialValue(int amount)
    {
        var _walletCustomer = new WalletCustomerService(_mockWallet, _mockWalletHistory);
        var result = await _walletCustomer.AddInitialMoney(amount);
        Assert.True(result);
    }


    [Theory]
    [InlineData(100)]
    [InlineData(1)]
    [InlineData(99999)]
    public async void CantAddInitialValue(int amount)
    {
        var _walletCustomer = new WalletCustomerService(_mockWallet, _mockWalletHistory);
        await _walletCustomer.AddInitialMoney(amount);
        var result = await _walletCustomer.AddInitialMoney(amount);
        Assert.False(result);
    }

    [Theory]
    [InlineData(150)]
    [InlineData(100)]
    [InlineData(99669)]
    public async void GiveMeAvailable(int amount)
    {
        var _walletCustomer = new WalletCustomerService(_mockWallet, _mockWalletHistory);
        await _mockWallet.AddMoney(amount);
        var initial = await _walletCustomer.GetAvailable();

        Assert.Equal(initial, amount);


    }

    [Fact]
    public async void ThrowInitialValueWalletZeroExceptionWhenIsZero()
    {
        var _walletCustomer = new WalletCustomerService(_mockWallet, _mockWalletHistory);

        await Assert.ThrowsAsync<InitialValueWalletZeroException>(async () => await _walletCustomer.AddInitialMoney(0));

    }

    [Fact]
    public async void ThrowInitialValueWalletZeroExceptionWhenIsLessThanZero()
    {
        var _walletCustomer = new WalletCustomerService(_mockWallet, _mockWalletHistory);

        await Assert.ThrowsAsync<InitialValueWalletZeroException>(async () => await _walletCustomer.AddInitialMoney(-19));

    }
}