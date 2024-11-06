using Simulator.Maps;
using System.Diagnostics;

namespace Simulator;

class Program
{
    static void Main(string[] args)
    {
        Lab5a();
        Lab5b();
    }

    static void Lab5a()
    {
        var rectangle = new Rectangle(new Point(1, 2), new Point(0, 1));
        Console.WriteLine(rectangle.ToString());

        //var rectangle2 = new Rectangle(new Point(1, 2), new Point(1, 1));
        //Console.WriteLine(rectangle2.ToString());

        var rectangle3 = new Rectangle(4, 3, 2, 1);
        Console.WriteLine(rectangle3.ToString());

        try
        {
            var rectangle4 = new Rectangle(new Point(1, 2), new Point(1, 1));
            Console.WriteLine(rectangle4.ToString());
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            //
        }

        Console.WriteLine(rectangle3.Contains(new Point(2, 1)));
        Console.WriteLine(rectangle3.Contains(new Point(1, 2)));
    }

    static void Lab5b()
    {
        SmallSquareMap squareMap = new SmallSquareMap(10);

        Point currentPos = new Point(0, 0);
        Console.WriteLine(currentPos);

        currentPos = squareMap.Next(currentPos, Direction.Up);
        currentPos = squareMap.NextDiagonal(currentPos, Direction.Up);

        Console.WriteLine(currentPos);

        for (int i = 0; i < 10; i++)
        {
            currentPos = squareMap.NextDiagonal(currentPos, Direction.Up);
            Console.WriteLine(currentPos);
        }

        try
        {
            SmallSquareMap squareMap1 = new SmallSquareMap(2);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

