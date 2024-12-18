namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

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
        return new Point((p.X + SizeX) % SizeX, (p.Y + SizeY) % SizeY);
    }
}
