using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            string whoMoves = _simulation.CurrentCreature.ToString();
            string moveName = _simulation.CurrentMoveName;

            _simulation.Turn();

            Dictionary<Point, char> symbols = new Dictionary<Point, char>();
            foreach(var kvp in _simulation.Map.fields)
                symbols.Add(kvp.Key, kvp.Value.Count > 1 ? 'X' : kvp.Value.Count > 0 ? kvp.Value.First().Symbol : ' ');

            TurnLogs.Add(new SimulationTurnLog() { Mappable = whoMoves, Move = moveName, Symbols = symbols });
        }
    }
}

//public class SimulationHisotry
//{
//    private readonly Simulation simulation;

//    private readonly List<IMappable?> mappables;
//    private readonly List<string> mapState;
//    private readonly List<string> moves;

//    public SimulationHisotry(Simulation simulation)
//    {
//        this.simulation = simulation;

//        mappables = new List<IMappable?>();
//        mapState = new List<string>();
//        moves = new List<string>();

//        mapState.Add(MapVisualizer.GetMap(simulation.Map));
//        mappables.Add(null);
//        moves.Add("Brak ruchu");

//        while (!simulation.Finished)
//        {
//            mappables.Add(simulation.CurrentCreature);
//            moves.Add(simulation.CurrentMoveName);

//            simulation.Turn();

//            mapState.Add(MapVisualizer.GetMap(simulation.Map));
//        }
//    }

//    public void DispalyMoveInfo(int moveNumber)
//    {
//        if (moveNumber >= mapState.Count) { throw new ArgumentOutOfRangeException("move number exceedes number of moves"); }

//        Console.WriteLine($"Move Number: {moveNumber}"
//            + $"\nWhat Moved : {mappables[moveNumber]}"
//            + $"\nWhere Moved : {moves[moveNumber]}"
//            + $"\n\n{mapState[moveNumber]}");
//    }
//}