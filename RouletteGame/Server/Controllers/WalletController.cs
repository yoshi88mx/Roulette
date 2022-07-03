using Microsoft.AspNetCore.Mvc;
using RouletteGame.Core.Wallet;
using RouletteGame.Shared;

namespace RouletteGame.Server.Controllers
{
    [ApiController]
    [Route("api/v1/wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IWallet wallet;

        public WalletController(IWallet wallet)
        {
            this.wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        }

        [HttpGet]
        [Route("balance")]
        public async Task<ActionResult<int>> GetTotal()
        {
            return await wallet.GetAvailable();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddMoney([FromQuery] int amount)
        {
            return await wallet.AddInitialMoney(amount);
        }

        [HttpGet]
        [Route("CanAdd")]
        public async Task<ActionResult<bool>> CanAdd()
        {
            return await wallet.CanAddInitialMoney();
        }
    }
}