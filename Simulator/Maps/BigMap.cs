using System.Net.Http.Headers;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX) + "too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY) + "too tall");
    }
}