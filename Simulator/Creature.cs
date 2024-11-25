using Simulator.Maps;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

public abstract class Creature
{

    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            if (value == null)
                return;

            name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public abstract int Power { get; }

    public abstract string Info { get; }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }


    public void Upgrade()
    {
        if (level >= 10)
            return;

        level++;
    }

    public virtual void SetMap(Map map, Point point)
    {
        Map = map;
        Position = point;

        map.Add(this, Position);
    }

    public void Go(Direction direction)
    {
        if (Map == null) throw new ArgumentNullException("Map not set!");

        Point NextPos = Map.Next(Position, direction);

        //if position didn't change, do nothing
        if (NextPos == Position) return;

        Map.Move(this, Position, NextPos);
        Position = NextPos;
    }

    public abstract string Greeting();

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

}

