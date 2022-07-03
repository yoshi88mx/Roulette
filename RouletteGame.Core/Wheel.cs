using RouletteGame.Core.Common;

namespace RouletteGame.Core
{
    public class Wheel: ISpinTheWheel
    {
        public List<WheelNumber> Numbers { get; private set; }

        public Wheel()
        {
            Numbers = new List<WheelNumber>() 
            { 
                new WheelNumber { Number = "0", Color = WheelColor.Green },
                new WheelNumber { Number = "00", Color = WheelColor.Green },
                new WheelNumber { Number = "1", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "2", Color = WheelColor.Red },
                new WheelNumber { Number = "3", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "4", Color = WheelColor.Red },
                new WheelNumber { Number = "5", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "6", Color = WheelColor.Red },
                new WheelNumber { Number = "7", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "8", Color = WheelColor.Red },
                new WheelNumber { Number = "9", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "10", Color = WheelColor.Red },
                new WheelNumber { Number = "11", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "12", Color = WheelColor.Red },
                new WheelNumber { Number = "13", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "14", Color = WheelColor.Red },
                new WheelNumber { Number = "15", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "16", Color = WheelColor.Red },
                new WheelNumber { Number = "17", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "18", Color = WheelColor.Red },
                new WheelNumber { Number = "19", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "20", Color = WheelColor.Red },
                new WheelNumber { Number = "21", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "22", Color = WheelColor.Red },
                new WheelNumber { Number = "23", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "24", Color = WheelColor.Red },
                new WheelNumber { Number = "25", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "26", Color = WheelColor.Red },
                new WheelNumber { Number = "27", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "28", Color = WheelColor.Red },
                new WheelNumber { Number = "29", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "30", Color = WheelColor.Red },
                new WheelNumber { Number = "31", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "32", Color = WheelColor.Red },
                new WheelNumber { Number = "33", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "34", Color = WheelColor.Red },
                new WheelNumber { Number = "35", Color = WheelColor.Black, IsOdd = true },
                new WheelNumber { Number = "36", Color = WheelColor.Red },

            };
        }

        public WheelNumber GiveMeANumber()
        {
            var random = new Random();

            var position = Enumerable.Range(0, 35)
                .OrderBy(i => random.Next())
                .First();

            Thread.Sleep(3000);

            return Numbers[position];
        }
    }
}