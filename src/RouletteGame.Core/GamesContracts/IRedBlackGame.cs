using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.GamesContracts;

public interface IRedBlackGame
{
    Task<bool> IsMyLuckyDay(string number, int bet);
}