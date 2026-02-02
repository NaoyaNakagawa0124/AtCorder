using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long N = long.Parse(readline[0]);
        readline = Console.ReadLine().Split();
        long[] A = new long[N];
        long[] times = new long[N];
        long pair_sum = 0;
        for (long i = 0; i < N; i++)
        {
            A[i] = long.Parse(readline[i]);
            times[A[i] - 1]++;
        }
        for (long i = 0; i < N; i++)
        {
            if (times[i] > 1)
            {
                pair_sum += (times[i] * (times[i] - 1)) / 2 * (N - times[i]);
            }
        }
        Console.WriteLine(pair_sum);
    }
}

