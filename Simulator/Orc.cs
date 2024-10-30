namespace Simulator;

public class Orc : Creature
{
    public int rage = 0;
    public int Rage
    {
        get => rage;
        init => rage = Math.Max(0, Math.Min(10, value));
    }

    public override int Power => 7 * Level + 3 * Rage;

    private int huntCount = 0;

    public Orc() : base() { }
    public Orc(string name = "Unknown", int level = 1, int rage = 0) : base(name, level)
    {
        huntCount = 0;
        Rage = rage;
    }
    public void Hunt()
    {
        huntCount++;
        if (huntCount % 2 == 0 && rage < 10)
        {
            rage++;
            huntCount = 0;
        }


        Console.WriteLine($"{Name} is hunting.");
    }
    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }
}
