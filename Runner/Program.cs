using Simulator;
using Simulator.Maps;
using System.Text;

namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            //List<Creature> creatures = new List<Creature>() { new Orc("Filip"), new Orc("Andrzej"), new Orc("Damian") };
            //List<Point> positions = new List<Point>() { new Point(1, 2), new Point(3, 4), new Point(5, 6) };


            //Simulation sim = new Simulation(new SmallSquareMap(7), creatures, positions, "uuddrlrludrl");
            //while (!sim.Finished)
            //{
            //    sim.Turn();
            //}

            Console.OutputEncoding = Encoding.UTF8;


            SmallSquareMap map = new(5);
            List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
            List<Point> points = [new(2, 2), new(3, 1)];
            string moves = "dlrludl";

            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);

            //SmallSquareMap map = new(9);
            //List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Orc("Janek"), new Elf("Maja"), new Orc("Terminator")];
            //List<Point> points = [new(2, 2), new(3, 1), new(7, 8), new(2, 8), new(5, 5)];
            ////string moves = "dlrludldlrludlddduuulrlrlrludlr";
            ////string moves = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";
            //string moves = "llllllllllllllllllllllluuuuuuuuuuuuuuuuuuuuuuuu";

            //Simulation simulation = new(map, creatures, points, moves);
            //MapVisualizer mapVisualizer = new(simulation.Map);

            Console.WriteLine("Starting Positions: ");
            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            while (!simulation.Finished)
            {
                Console.WriteLine($"<{simulation.CurrentCreature.GetType().Name} - {simulation.CurrentCreature.Info}> " +
                    $"from {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}");

                simulation.Turn();
                mapVisualizer.Draw();

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
