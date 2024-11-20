namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string args)
    {
        List<Direction> resultList = new();
        foreach (var arg in args)
        {
            switch (arg.ToString().ToLower())
            {
                case "u":
                    resultList.Add(Direction.Up);
                    break;
                case "r":
                    resultList.Add(Direction.Right);
                    break;
                case "d":
                    resultList.Add(Direction.Down);
                    break;
                case "l":
                    resultList.Add(Direction.Left);
                    break;
                default:
                    break;

            }
        }

        return resultList;
    }
}
