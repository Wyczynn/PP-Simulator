using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map map;

    public MapVisualizer(Map map) => this.map = map;

    public void Draw()
    {
        DrawTop();
        for (int i = 0; i < map.SizeY; i++)
        {
            DrawCreatures(i);

            if (i != map.SizeY - 1)
                DrawMiddle();
        }
        DrawBottom();
    }

    private void DrawTop()
    {
        Console.Write(Box.TopLeft);
        for (int i = 1; i < map.SizeX; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.TopMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.TopRight);

        Console.WriteLine();
    }

    private void DrawBottom()
    {
        Console.Write(Box.BottomLeft);
        for (int i = 1; i < map.SizeX; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.BottomMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.BottomRight);

        Console.WriteLine();
    }

    private void DrawMiddle()
    {
        Console.Write(Box.MidLeft);
        for (int i = 1; i < map.SizeX; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.Cross);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.MidRight);

        Console.WriteLine();
    }

    private void DrawCreatures(int row)
    {
        Console.Write(Box.Vertical);
        for (int i = 0; i < map.SizeX; i++)
        {
            List<Creature>? creaturesAt = map.At(i, map.SizeY - 1 - row);
            char toDraw = creaturesAt?.Count > 1 ? 'X' : creaturesAt?.First().GetType().Name[0] ?? ' ';

            Console.Write($"{toDraw}{Box.Vertical}");

        }
        Console.WriteLine();
    }
}