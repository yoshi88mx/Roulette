using Microsoft.AspNetCore.Mvc;
using RouletteGame.Core.Wallet;
using RouletteGame.Shared;

namespace RouletteGame.Server.Controllers;

[ApiController]
[Route("api/v1/wallet")]
public class WalletController : ControllerBase
{
    private readonly IWalletCustomer _wallet;
    private readonly IWalletHistoryCustomer _walletHistoryCustomer;

    public WalletController(IWalletCustomer wallet, IWalletHistoryCustomer walletHistoryCustomer)
    {
        _wallet = wallet;
        _walletHistoryCustomer = walletHistoryCustomer;
    }

    [HttpGet]
    [Route("balance")]
    public async Task<ActionResult<int>> GetTotal()
    {
        return await _wallet.GetAvailable();
    }

    [HttpPost]
    public async Task<ActionResult<bool>> AddMoney([FromQuery] int amount)
    {
        return await _wallet.AddInitialMoney(amount);
    }

    [HttpGet]
    [Route("CanAdd")]
    public async Task<ActionResult<bool>> CanAdd()
    {
        return await _wallet.CanAddInitialMoney();
    }

    [HttpGet]
    [Route("history")]
    public async Task<ActionResult<List<WalletHistoryDto>>> GetHistory()
    {
        return await _walletHistoryCustomer.GetHistory();
    }
}