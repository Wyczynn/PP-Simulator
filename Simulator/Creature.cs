using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

public class Creature
{

    private string name = "Unknown";
    public string? Name
    {
        get => name;
        init
        {
            if (value == null)
                return;

            string temp = String.Join(" ", value.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            if (temp.Length < 3)
            {
                while(temp.Length < 3)
                {
                    temp += "#";
                }
            }
            temp = temp[0].ToString().ToUpper() + temp[1..];
            name = temp[..Math.Min(temp.Length, 25)].TrimEnd();
        }
    }

    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            level = Math.Max(1, Math.Min(10, value));
        }
    }
    public string Info => $"{Name} [{Level}]";

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


    public void Upgrade()
    {
        if (level >= 10)
            return;

        level++;
    }
}
