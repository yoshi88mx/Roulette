using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Core.GamesContracts;
public interface IOneTwoTree
{
    Task<bool> IsMyLuckyDay(int bet);
}