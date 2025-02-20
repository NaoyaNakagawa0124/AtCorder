using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var line = Console.ReadLine().Split();
        int N = int.Parse(line[0]);
        int M = int.Parse(line[1]);
        var used = new HashSet<(int,int)>();
        int count = 0;

        for (int i = 0; i < M; i++)
        {
            var e = Console.ReadLine().Split();
            int v1 = int.Parse(e[0]);
            int v2 = int.Parse(e[1]);

            if (v1 == v2)
            {
                count++; 
                continue; 
            }

            if (v1 > v2)
            {
                int tmp = v1;
                v1 = v2;
                v2 = tmp;
            }

            if (used.Contains((v1, v2)))
            {
                count++; 
            }
            else
            {
                used.Add((v1, v2)); 
            }
        }

        Console.WriteLine(count);
    }
}
