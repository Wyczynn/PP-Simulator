using System;

namespace Simulator;

public class Elf : Creature
{
    public int agility = 0;
    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }

    public override int Power => 8 * Level + 2 * Agility;
    public override string Info => $"{Name} [{Level}][{Agility}]";

    private int singCount = 0;

    public Elf() : base() { }
    public Elf(string name = "Unknown", int level = 1, int agility = 0) : base(name, level)
    {
        singCount = 0;
        Agility = agility;
    }

    public void Sing()
    {
        singCount++;
        if (singCount % 3 == 0 && agility < 10)
        {
            agility++;
            singCount = 0;
        }

         Console.WriteLine($"{Name} is singing.");
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }
}