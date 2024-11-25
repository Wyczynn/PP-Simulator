using Simulator;
using Simulator.Maps;

namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            Orc orc = new Orc();

            SmallSquareMap map = new(10);

            orc.SetMap(map, new Point(4, 5));


            Console.WriteLine(map.At(4, 5)?.First().Position); 
            map.Remove(orc, orc.Position);
            Console.WriteLine(map.At(4, 5)?.First().Position);
        }
    }
}
