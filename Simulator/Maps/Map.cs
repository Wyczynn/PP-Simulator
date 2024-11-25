using System.Drawing;

namespace Simulator.Maps;
/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private int sizeX, sizeY;
    public int SizeX
    {
        get => sizeX;
        init
        {
            if(value < 5) throw new ArgumentOutOfRangeException(nameof(sizeX) + "too narrow");

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

    public abstract void Add(Creature creature, Point position);
    public abstract void Remove(Creature creature, Point position);

    public virtual void Move(Creature creature, Point currentPosition, Point endPosition)
    {
        Remove(creature, currentPosition);
        Add(creature, endPosition);
    }

    public List<Creature>? At(int x, int y) => At(new Point(x, y));
    public abstract List<Creature>? At(Point point);
}