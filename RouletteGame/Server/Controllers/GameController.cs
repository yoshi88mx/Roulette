using Microsoft.AspNetCore.Mvc;
using RouletteGame.Server.Services;

namespace RouletteGame.Server.Controllers;

[ApiController]
[Route("api/v1/games/")]
public class GameController : ControllerBase
{
    private readonly EvenOddService _evenOddService;
    private readonly RedBackService _redBackService;
    private readonly SingleNumberService _singleNumberService;

    public GameController(EvenOddService evenOddService, RedBackService redBackService, SingleNumberService singleNumberService)
    {
        _evenOddService = evenOddService;
        _redBackService = redBackService;
        _singleNumberService = singleNumberService;
    }

    [HttpGet]
    [Route("EvenOdd")]
    public async Task<ActionResult<bool>> EvenOddGame([FromQuery] string number, [FromQuery] int bet)
    {
        return await _evenOddService.IsMyLuckyDay(number, bet);
    }

    [HttpGet]
    [Route("RedBlack")]
    public async Task<ActionResult<bool>> RedBlackGame([FromQuery] string color, [FromQuery] int bet)
    {
        return await _redBackService.IsMyLuckyDay(color, bet);
    }

    [HttpGet]
    [Route("singlenumber")]
    public async Task<ActionResult<bool>> SingleNumerGame([FromQuery] string number, [FromQuery] int bet)
    {
        return await _singleNumberService.IsMyLuckyDay(number, bet);
    }
}
