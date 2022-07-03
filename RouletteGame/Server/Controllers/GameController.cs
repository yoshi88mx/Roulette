using Microsoft.AspNetCore.Mvc;
using RouletteGame.Server.Services;

namespace RouletteGame.Server.Controllers
{
    [ApiController]
    [Route("api/v1/games/")]
    public class GameController : ControllerBase
    {
        private readonly EvenOddService evenOddService;
        private readonly RedBackService redBackService;

        public GameController(EvenOddService evenOddService, RedBackService redBackService)
        {
            this.evenOddService = evenOddService ?? throw new ArgumentNullException(nameof(evenOddService));
            this.redBackService = redBackService ?? throw new ArgumentNullException(nameof(redBackService));
        }

        [HttpGet]
        [Route("EvenOdd")]
        public async Task<ActionResult<bool>> EvenOddGame([FromQuery] string number, [FromQuery] int bet)
        {
            return await evenOddService.IsMyLuckyDay(number, bet);
        }

        [HttpGet]
        [Route("RedBlack")]
        public async Task<ActionResult<bool>> RedBlackGame([FromQuery] string color, [FromQuery] int bet)
        {
            return await redBackService.IsMyLuckyDay(color, bet);
        }
    }
}
