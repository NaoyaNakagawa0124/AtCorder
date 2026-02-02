using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long H = long.Parse(readline[0]);
        long W = long.Parse(readline[1]);
        long N = long.Parse(readline[2]);

        long[,] grid = new long[H, W];
        long[]  question = new long[N];

        long ans = 0;

        for(long i = 0; i < H; i++)
        {
            readline = Console.ReadLine().Split();
            for(long j = 0; j < W; j++)
            {
                grid[i, j] = long.Parse(readline[j]);
            }
        }

        for(long i = 0; i < N; i++)
        {
            readline = Console.ReadLine().Split();
            question[i] = long.Parse(readline[0]);
        }

        for(int i = 0; i < H; i++)
        {
            long count = 0;
            for(int j = 0; j < W; j++)
            {
                foreach(long k in question)
                {
                    if(grid[i, j] == k)
                    {
                        count++;
                    }
                }
            }
            ans = Math.Max(ans, count);
        }

        Console.WriteLine(ans);
    }
}

