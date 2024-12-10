using Simulator.Maps;

namespace SimConsole;

public class SimulationHisotry
{
    private readonly Simulation simulation;

    private readonly List<IMappable?> mappables;
    private readonly List<string> mapState;
    private readonly List<string> moves;

    public SimulationHisotry(Simulation simulation)
    {
        this.simulation = simulation;

        mappables = new List<IMappable?>();
        mapState = new List<string>();
        moves = new List<string>();

        mapState.Add(MapVisualizer.GetMap(simulation.Map));
        mappables.Add(null);
        moves.Add("Brak ruchu");

        while (!simulation.Finished)
        {
            mappables.Add(simulation.CurrentCreature);
            moves.Add(simulation.CurrentMoveName);

            simulation.Turn();

            mapState.Add(MapVisualizer.GetMap(simulation.Map));
        }
    }

    public void DispalyMoveInfo(int moveNumber)
    {
        if (moveNumber >= mapState.Count) { throw new ArgumentOutOfRangeException("move number exceedes number of moves"); }

        Console.WriteLine($"Move Number: {moveNumber}"
            + $"\nWhat Moved : {mappables[moveNumber]}"
            + $"\nWhere Moved : {moves[moveNumber]}"
            + $"\n\n{mapState[moveNumber]}");
    }
}