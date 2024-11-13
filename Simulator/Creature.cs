using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

public abstract class Creature
{

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

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
    public string[] Go(Direction[] directions)
    {
        List<string> list = new List<string>();
        foreach (var direction in directions)
        {
            list.Add(Go(direction));
        }

        return list.ToArray();
    }

    public string[] Go(string directionArguments)
    {
        List<string> list = new List<string>();
        foreach (var direction in DirectionParser.Parse(directionArguments))
        {
            list.Add(Go(direction));
        }

        return list.ToArray();
    }
    public abstract string Greeting();

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

}

