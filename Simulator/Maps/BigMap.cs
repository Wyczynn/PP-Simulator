using System.Net.Http.Headers;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    readonly Dictionary<Point, List<IMappable>> fields;

    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX) + "too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY) + "too tall");

        fields = new Dictionary<Point, List<IMappable>>();
    }

    public override void Add(IMappable mappable, Point position)
    {
        fields.TryGetValue(position, out var list);

        if (list != null)
            list.Add(mappable);
        else
            fields[position] = new List<IMappable> { mappable };
    }

    public override void Remove(IMappable mappable, Point position)
    {
        if (fields.TryGetValue(position, out var list))
            list.Remove(mappable);
    }

    public override List<IMappable>? At(Point position)
    {
        return fields.TryGetValue(position, out var list) ? (list.Count > 0 ? list : null) : null;
    }
}