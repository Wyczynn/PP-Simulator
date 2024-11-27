namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    readonly List<IMappable>?[,] fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX) + "too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY) + "too tall");

        fields = new List<IMappable>?[sizeX, sizeY];
    }

    public override void Add(IMappable mappable, Point position)
    {
        fields[position.X, position.Y] ??= new List<IMappable>();

        fields[position.X, position.Y]?.Add(mappable);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        fields[position.X, position.Y]?.Remove(mappable);

        if (fields[position.X, position.Y]?.Count == 0)
            fields[position.X, position.Y] = null;
    }

    public override List<IMappable>? At(Point position) => fields[position.X, position.Y];
}