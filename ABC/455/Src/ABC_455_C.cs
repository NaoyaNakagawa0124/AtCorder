using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        SortedDictionary<long, long> A_Sort = new SortedDictionary<long, long>();

        int N = int.Parse(readline[0]);
        int K = int.Parse(readline[1]);

        readline = Console.ReadLine().Split();

        for (int i = 0; i < readline.Length; i++)
        {
            long tmp = long.Parse(readline[i]);
            if (A_Sort.ContainsKey(tmp))
            {
                A_Sort[tmp] += tmp;
            }
            else
            {
                A_Sort.Add(tmp, tmp);
            }
        }

        var sorted = A_Sort.Values.OrderByDescending(x => x).ToList();
        long ans = 0;
        for (int i = 0; i < sorted.Count; i++)
        {
            long value = sorted[i]; 
            if (i >= K)
            {
                ans += value;
            }
        }
        Console.Write(ans);
    }
}

