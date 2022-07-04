using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.GamesContracts;
public interface ILowHighGame
{
    Task<bool> IsMyLuckyDay(int bet);
}