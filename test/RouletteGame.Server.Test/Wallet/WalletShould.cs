using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using RouletteGame.Core.Wallet;
using RouletteGame.Server.Services;
using Xunit;

namespace RouletteGame.Server.Test.Wallet;

public class WalletShould
{
    private readonly WalletService _wallet;

    public WalletShould()
    {
        var mockLogger = new Mock<ILogger<WalletService>>();
        var mockAutoMapper = new Mock<IMapper>();
        var mockWalletHistory = new Mock<IWalletHistoryCustomer>();
        _wallet = new WalletService(mockLogger.Object, mockAutoMapper.Object, mockWalletHistory.Object);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(99999)]
    public async void CanAddMoney(int amount)
    {
        var InitialTotal = _wallet.Total;

        await _wallet.AddMoney(amount);

        Assert.Equal(InitialTotal + amount, _wallet.Total);
    }

    [Theory]
    [InlineData(100, 10)]
    [InlineData(40, 20)]
    [InlineData(11000, 10000)]
    public async void CanRemoveMoney(int initialValue, int amount)
    {
        _wallet.Total = initialValue;

        await _wallet.RemoveMoney(amount);

        Assert.Equal(initialValue - amount, _wallet.Total);
    }
}