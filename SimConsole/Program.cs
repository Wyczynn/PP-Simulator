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

            SmallTorusMap map = new(6, 8);
            List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals { Description = "Króliki", Size = 10},
                                            new Birds {Description = "Orły", Size = 10, CanFly = true},
                                            new Birds {Description = "Strusie", Size = 8, CanFly = false}];
            List<Point> points = [new(2, 2), new(3, 1), new(4, 2), new(3, 5), new(3, 3)];
            string moves = "dlrludllrlrdurldurllldddurrr";

            Simulation simulation = new(map, mappables, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);

            Console.WriteLine("Starting Positions: ");
            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            while (!simulation.Finished)
            {
                Console.WriteLine($"<{simulation.CurrentCreature.GetType().Name} - " +
                    $"{(simulation.CurrentCreature is Creature creature ? creature.Name + " from " + creature.Position : "")}> " +
                    $"goes {simulation.CurrentMoveName}");

                simulation.Turn();
                mapVisualizer.Draw();

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
