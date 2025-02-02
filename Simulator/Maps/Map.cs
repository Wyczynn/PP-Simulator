﻿namespace Simulator.Maps;
/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public readonly Dictionary<Point, List<IMappable>> fields;

    private int sizeX, sizeY;
    public int SizeX
    {
        get => sizeX;
        init
        {
            if (value < 5) throw new ArgumentOutOfRangeException(nameof(sizeX) + "too narrow");

            sizeX = value;
        }
    }
    public int SizeY
    {
        get => sizeY;
        init
        {
            if (value < 5) throw new ArgumentOutOfRangeException(nameof(sizeY) + "too short");

            sizeY = value;
        }
    }

    protected Map(int sizeX, int sizeY)
    {
        SizeX = sizeX;
        SizeY = sizeY;

        fields = new Dictionary<Point, List<IMappable>>();
    }


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        //if dla czytelności kodu : )
        if (p.X < 0 || p.X > SizeX - 1 || p.Y < 0 || p.Y > SizeY - 1)
            return false;

        return true;
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    //public abstract void Add(IMappable mappable, Point position);
    //public abstract void Remove(IMappable mappable, Point position);

    public virtual void Add(IMappable mappable, Point position)
    {
        fields.TryGetValue(position, out var list);

        if (list != null)
            list.Add(mappable);
        else
            fields[position] = new List<IMappable> { mappable };
    }

    public virtual void Remove(IMappable mappable, Point position)
    {
        if (fields.TryGetValue(position, out var list))
            list.Remove(mappable);
    }

    public virtual void Move(IMappable mappable, Point currentPosition, Point endPosition)
    {
        Remove(mappable, currentPosition);
        Remove(mappable, currentPosition);
        Add(mappable, endPosition);
    }

    public List<IMappable>? At(int x, int y) => At(new Point(x, y));
    public virtual List<IMappable>? At(Point position)
    {
        return fields.TryGetValue(position, out var list) ? (list.Count > 0 ? list : null) : null;
    }
    //public abstract List<IMappable>? At(Point point);
}