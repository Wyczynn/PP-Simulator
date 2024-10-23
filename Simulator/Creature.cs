using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

public class Creature
{
    public string? Name;
    public int Level;

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public string Info()
    {
        return $"{Name} [{Level}]";
    }
}
