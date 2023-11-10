using System;
namespace TimelineSort;

public class Program
{
    public static void Main()
    {

        List<List<object>> a = new List<List<object>>
        {
            new List<object>{ "A", "B", "C", "D", "E", "H" },
            new List<object>{ "A", "C", "D", "E", "F", "B", "H"},
            new List<object>{ "A", "D", "E", "H", "G"}
        };

        var o = new TimelineSort(a);
        Print(o.Pattern);
        Print(o.Get(a[0]));
        Print(o.Get(a[1]));
        Print(o.Get(a[2]));
        
    }

    public static void Print(List<object> objs)
    {
        foreach (var o in objs)
        {
            if (o == null)
                Console.Write("  ");
            else
                Console.Write(o + " ");
        }
        Console.WriteLine();
    }
}
