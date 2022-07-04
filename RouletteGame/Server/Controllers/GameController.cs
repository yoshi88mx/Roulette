using Microsoft.AspNetCore.Mvc;
using RouletteGame.Core.GamesContracts;
using RouletteGame.Server.Services;

namespace RouletteGame.Server.Controllers;

[ApiController]
[Route("api/v1/games/")]
public class GameController : ControllerBase
{
    private readonly IOddEvenGame _evenOddService;
    private readonly IRedBlackGame _redBackService;
    private readonly ISingleNumerGame _singleNumberService;

    public GameController(IOddEvenGame evenOddService, IRedBlackGame redBackService, ISingleNumerGame singleNumberService)
    {
        _evenOddService = evenOddService;
        _redBackService = redBackService;
        _singleNumberService = singleNumberService;
    }

    [HttpGet]
    [Route("EvenOdd")]
    public async Task<ActionResult<bool>> EvenOddGame([FromQuery] bool isOdd, [FromQuery] int bet)
    {
        return await _evenOddService.IsMyLuckyDay(isOdd, bet);
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
