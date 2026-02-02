using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long N = long.Parse(readline[0]);
        long M = long.Parse(readline[1]);

        long[] Sum_Big = new long[M + 1];
        long[] Sum_Number = new long[M + 1];
        for(int i = 1; i <= N; i++)
        {
            readline = Console.ReadLine().Split();
            long type = long.Parse(readline[0]);
            long big = long.Parse(readline[1]);

            Sum_Big[type] += big;
            Sum_Number[type] ++;
        }
        for(int i = 1; i <= M; i++)
        {
            double avg = (double)Sum_Big[i] / Sum_Number[i];
            Console.WriteLine(avg);
        }
    }
}

