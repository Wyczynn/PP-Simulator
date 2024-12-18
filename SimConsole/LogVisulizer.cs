using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class LogVisulizer
{
    SimulationHistory Log { get; }

    public LogVisulizer(SimulationHistory log)
    {
        Log = log;

        int i = 0;
        foreach(var item in log.TurnLogs)
        {
            Console.WriteLine($"{item.Mappable} moved: {item.Move}");
            Draw(i++);
        }
    }

    public void Draw(int turnIndex)
    {
        string temp = "";

        temp += DrawTop(Log.SizeX);
        for (int i = 0; i < Log.SizeY; i++)
        {
            temp += DrawCreaturesMap(i, Log.SizeY, Log.SizeX, turnIndex);

            if (i != Log.SizeY - 1)
                temp += DrawMiddle(Log.SizeX);
        }
        temp += DrawBottom(Log.SizeX);

        Console.WriteLine(temp);
    }

    private string DrawTop(int SizeX)
    {
        string temp = "";

        temp += Box.TopLeft;
        for (int i = 1; i < SizeX; i++)
        {
            temp += Box.Horizontal;
            temp += Box.TopMid;
        }
        temp += Box.Horizontal;
        temp += Box.TopRight;

        temp += "\n";

        return temp;
    }

    private string DrawBottom(int SizeX)
    {
        string temp = "";

        temp += Box.BottomLeft;
        for (int i = 1; i < SizeX; i++)
        {
            temp += Box.Horizontal;
            temp += Box.BottomMid;
        }
        temp += Box.Horizontal;
        temp += Box.BottomRight;

        temp += "\n";

        return temp;
    }

    private string DrawMiddle(int SizeX)
    {
        string temp = "";

        temp += Box.MidLeft;
        for (int i = 1; i < SizeX; i++)
        {
            temp += Box.Horizontal;
            temp += Box.Cross;
        }
        temp += Box.Horizontal;
        temp += Box.MidRight;

        temp += "\n";

        return temp;
    }

    private string DrawCreaturesMap(int row, int SizeY, int SizeX, int turnIndex)
    {
        string temp = "";

        temp += Box.Vertical;
        for (int i = 0; i < SizeX; i++)
        {
            if(!Log.TurnLogs[turnIndex].Symbols.TryGetValue(new Point(i, SizeY - 1 - row), out char toDraw))
                toDraw = ' ';


            temp += $"{toDraw}{Box.Vertical}";

        }
        temp += "\n";

        return temp;
    }
}