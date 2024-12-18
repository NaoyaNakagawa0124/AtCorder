using System;
using System.Collections.Generic;
class Program
{
    static int Main()
    {

        string[] readline = Console.ReadLine().Split();
        int A = int.Parse(readline[0]);
        int B = int.Parse(readline[1]);
        int C = int.Parse(readline[2]);
        int D = int.Parse(readline[3]);
        int E = int.Parse(readline[4]);

        List<(int, string)> ans = new List<(int, string)>();

        ans.Add((A, "A"));
        ans.Add((B, "B"));
        ans.Add((C, "C"));
        ans.Add((D, "D"));
        ans.Add((E, "E"));
        ans.Add((A + B, "AB"));
        ans.Add((A + C, "AC"));
        ans.Add((A + D, "AD"));
        ans.Add((A + E, "AE"));
        ans.Add((B + C, "BC"));
        ans.Add((B + D, "BD"));
        ans.Add((B + E, "BE"));
        ans.Add((C + D, "CD"));
        ans.Add((C + E, "CE"));
        ans.Add((D + E, "DE"));
        ans.Add((A + B + C, "ABC"));
        ans.Add((A + B + D, "ABD"));
        ans.Add((A + B + E, "ABE"));
        ans.Add((A + C + D, "ACD"));
        ans.Add((A + C + E, "ACE"));
        ans.Add((A + D + E, "ADE"));
        ans.Add((B + C + D, "BCD"));
        ans.Add((B + C + E, "BCE"));
        ans.Add((B + D + E, "BDE"));
        ans.Add((C + D + E, "CDE"));
        ans.Add((A + B + C + D, "ABCD"));
        ans.Add((A + B + C + E, "ABCE"));
        ans.Add((A + B + D + E, "ABDE"));
        ans.Add((A + C + D + E, "ACDE"));
        ans.Add((B + C + D + E, "BCDE"));
        ans.Add((A + B + C + D + E, "ABCDE"));

        ans.Sort((x, y) =>
        {
            int primaryComparison = y.Item1.CompareTo(x.Item1); 
            if (primaryComparison == 0)
            {
                return StringComparer.Ordinal.Compare(x.Item2, y.Item2); 
            }
            return primaryComparison;
        });

        foreach (var item in ans)
        {
            Console.WriteLine(item.Item2);
        }
        return 0;
    }
}