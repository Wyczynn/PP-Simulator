namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException("Nieprawidłowy rozmiar mapy");

        Size = size;
    }

    public override bool Exist(Point p)
    {
        if (p.X < 0 || p.X > Size - 1 || p.Y < 0 || p.Y > Size - 1)
            return false;

        return true;
    }

    public override Point Next(Point p, Direction d)
    {
        return ValidatePoint(p.Next(d));
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return ValidatePoint(p.NextDiagonal(d));
    }

    private Point ValidatePoint(Point p)
    {
        Point temp = new Point((p.X + Size) % Size, (p.Y + Size) % Size);

        return temp;
    }
}
