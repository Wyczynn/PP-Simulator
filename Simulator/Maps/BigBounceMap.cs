namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    private readonly Dictionary<Direction, Direction> oppositeDirection = new Dictionary<Direction, Direction>()
    {
        {Direction.Left, Direction.Right },
        {Direction.Right, Direction.Left },
        {Direction.Up, Direction.Down },
        {Direction.Down, Direction.Up },
    };

    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        if (Exist(p.Next(d)))
            return p.Next(d);
        else if (Exist(p.Next(oppositeDirection[d])))
            return p.Next(oppositeDirection[d]);

        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d)))
            return p.NextDiagonal(d);
        else if (Exist(p.NextDiagonal(oppositeDirection[d])))
            return p.NextDiagonal(oppositeDirection[d]);

        return p;
    }
}