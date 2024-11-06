using System.Diagnostics;

namespace Simulator;

class Program
{
    static void Main(string[] args)
    {
        Lab5a();
    }

    static void Lab5a()
    {
        // **W czasie wykonywania zadania nie było dostępnej metody do skopiowania

        var rectangle = new Rectangle(new Point(1, 2), new Point(0, 1));
        Console.WriteLine(rectangle.ToString());

        //var rectangle2 = new Rectangle(new Point(1, 2), new Point(1, 1));
        //Console.WriteLine(rectangle2.ToString());

        var rectangle3 = new Rectangle(4,3,2,1);
        Console.WriteLine(rectangle3.ToString());

        try
        {
            var rectangle4 = new Rectangle(new Point(1, 2), new Point(1, 1));
            Console.WriteLine(rectangle4.ToString());
        }
        catch(ArgumentException e)
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
}

