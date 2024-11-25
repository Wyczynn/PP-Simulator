namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    readonly List<Creature>?[,] fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX) + "too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY) + "too tall");

        fields = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point position)
    {
        fields[position.X, position.Y] ??= new List<Creature>();

        fields[position.X, position.Y]?.Add(creature);
    }

    public override void Remove(Creature creature, Point position)
    {
        fields[position.X, position.Y]?.Remove(creature);

        if (fields[position.X, position.Y]?.Count == 0)
            fields[position.X, position.Y] = null;
    }

    public override List<Creature>? At(Point position) => fields[position.X, position.Y];
}