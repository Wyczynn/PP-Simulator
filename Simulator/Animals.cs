using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    public string description = "";
    public required string Description
    {
        get => description;
        init
        {
            if (value == null)
                return;

            string temp = String.Join(" ", value.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            if (temp.Length < 3)
            {
                while (temp.Length < 3)
                {
                    temp += "#";
                }
            }
            temp = temp[0].ToString().ToUpper() + temp[1..];
            description = temp[..Math.Min(temp.Length, 15)].TrimEnd();
        }
    }
    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
