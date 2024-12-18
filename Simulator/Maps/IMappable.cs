namespace Simulator.Maps;

public interface IMappable
{
    //public Map? Map { get; set; }
    //public Point Position { get; set; }

    public char Symbol { get; }

    public void SetMap(Map map, Point point);

    public void Go(Direction direction);

    public string ToString();
}

