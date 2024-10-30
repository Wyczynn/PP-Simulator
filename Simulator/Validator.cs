namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        return Math.Max(min, Math.Min(max, value));
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        string temp = String.Join(" ", value.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

        if (temp.Length < min)
        {
            while (temp.Length < min)
            {
                temp += placeholder;
            }
        }
        temp = temp[0].ToString().ToUpper() + temp[1..];
        temp = temp[..Math.Min(temp.Length, max)].TrimEnd();


        return temp;
    }
}


