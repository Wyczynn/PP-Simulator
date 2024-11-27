using Simulator.Maps;
using Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }
    private readonly List<Direction> movesList;
    private int movesIndex = 0;

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished => movesIndex == movesList.Count;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    private int currentCreatureIndex = 0;
    public IMappable CurrentCreature => Creatures[currentCreatureIndex];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => movesList[movesIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables.Count == 0) throw new ArgumentException("Creatures list is Empty!");
        if (mappables.Count != positions.Count) throw new ArgumentException("Positions and Creatures don't match!");

        Map = map;
        Creatures = mappables;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < mappables.Count; i++)
        {
            //if (Creatures[i].Map != Map)
            //{
                //ponieważ sprawdziliśmy że positions i creatures mają taką samą długość
                Creatures[i].SetMap(Map, Positions[i]);
            //}
        }

        movesList = DirectionParser.Parse(Moves);
    }


    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished) throw new InvalidOperationException("Simluations already finished!!!");

        CurrentCreature.Go(movesList[movesIndex++]);
        currentCreatureIndex = (currentCreatureIndex + 1) % Creatures.Count;
    }
}