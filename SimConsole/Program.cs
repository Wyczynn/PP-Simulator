using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            //SmallSquareMap map = new(5);
            //List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor")];
            //List<Point> points = [new(2, 2), new(3, 1)];
            //string moves = "dlrludl";


            //SmallSquareMap map = new(9);
            //List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Orc("Janek"), new Elf("Maja"), new Orc("Terminator")];
            //List<Point> points = [new(2, 2), new(3, 1), new(7, 8), new(2, 8), new(5, 5)];
            ////string moves = "dlrludldlrludlddduuulrlrlrludlr";
            ////string moves = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";
            //string moves = "llllllllllllllllllllllluuuuuuuuuuuuuuuuuuuuuuuu";

            //Simulation simulation = new(map, creatures, points, moves);
            //MapVisualizer mapVisualizer = new(simulation.Map);

            //SmallTorusMap map = new(6, 8);
            //List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals { Description = "Króliki", Size = 10},
            //                                new Birds {Description = "Orły", Size = 10, CanFly = true},
            //                                new Birds {Description = "Strusie", Size = 8, CanFly = false}];

            BigBounceMap bigBounceMap = new BigBounceMap(8, 6);

            Elf elf = new Elf();
            Orc orc = new Orc();
            Animals rabbits = new Animals() { Description = "Rabbits" };
            Birds ostrichs = new Birds() { Description = "Ostrichs" };
            Birds eagles = new Birds() { Description = "Eagles" };

            List<IMappable> mappables = new List<IMappable>() { elf, orc, rabbits, ostrichs, eagles };
            List<Point> points = [new(7, 2), new(4, 5), new(4, 2), new(7, 5), new(3, 3)];

            string moves = "rrrrrdllrlrdurldurllldddurrr";

            Simulation simulation = new(bigBounceMap, mappables, points, moves);
            SimulationHistory simulationHistory = new(simulation);

            foreach(var turn in simulationHistory.TurnLogs)
            {
                Console.WriteLine(turn.Mappable + turn.Move + "\t" + turn.Symbols);
            }

            //Console.WriteLine("Starting Positions: ");
            //Console.WriteLine(MapVisualizer.GetMap(simulation.Map));
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();

            //while (!simulation.Finished)
            //{
            //    Console.WriteLine($"<{simulation.CurrentCreature.GetType().Name} - " +
            //        $"{(simulation.CurrentCreature is Creature creature ? creature.Name + " from " + creature.Position : "")}> " +
            //        $"goes {simulation.CurrentMoveName}");

            //    simulation.Turn();
            //    Console.WriteLine(MapVisualizer.GetMap(simulation.Map));

            //    Console.WriteLine("Press any key to continue...");
            //    Console.ReadLine();
            //}
        }
    }
}
