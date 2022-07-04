using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RouletteGame.Core.Wallet;
using RouletteGame.Server.Profile;
using RouletteGame.Server.Services;
using Xunit;

namespace RouletteGame.Server.Test.Wallet;
public class WalletHistoryShould
{
    private readonly Mapper _mapper;

    public WalletHistoryShould()
    {
        var myProfile = new HistoryProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        _mapper = new Mapper(configuration);
    }

    [Fact]
    public async void HaveEmptyHistory()
    {
        var service = new WalletHistoryCustomerService(_mapper);
        Assert.Empty(await service.GetHistory());
    }

    [Fact]
    public async void ReturnHistory()
    {
        var service = new WalletHistoryCustomerService(_mapper);
        await service.Add(new WalletHistory());
        Assert.NotEmpty(await service.GetHistory());
    }

    [Fact]
    public async void CanAddHistory()
    {
        var now = DateTime.Now;
        var history = new WalletHistory() { Amonut = 100, Date = now, IsPositive = true };
        var service = new WalletHistoryCustomerService(_mapper);
        await service.Add(history);
        var historyes = await service.GetHistory();
        Assert.Equal(history.Date, historyes.First().Date);
        Assert.Equal(history.Amonut, historyes.First().Amonut);
        Assert.Equal(history.IsPositive, historyes.First().IsPositive);
    }


}
