//using RouletteGame.Core.Common;

//namespace RouletteGame.Core;

//public class Wheel : IWheel
//{
//    public List<WheelNumber> Numbers { get; private set; }

//    public Wheel()
//    {
        
//    }

//    public WheelNumber GiveMeANumber()
//    {
//        var random = new Random();

//        var position = Enumerable.Range(0, 35)
//            .OrderBy(i => random.Next())
//            .First();

//        Thread.Sleep(3000);

//        return Numbers[position];
//    }
//}
