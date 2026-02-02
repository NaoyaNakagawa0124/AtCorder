using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        long N = long.Parse(Console.ReadLine());
        long[][] grid = new long[2001][2001];
        for (int i = 0; i < N; i++)
        {
            string[] readline = Console.ReadLine().Split();
            int U = int.Parse(readline[0]);
            int D = int.Parse(readline[1]);
            int L = int.Parse(readline[2]);
            int R = int.Parse(readline[3]);

            // x方向の境界
            grid[U][L]++;
            if(R + 1 <= 2000)
            {
                grid[U][R + 1]--;
            }

            // y方向の境界
            if(D + 1 <= 2000)
            {
                grid[D + 1][L]--;
            }

            // 帳尻合わせ
            if(R + 1 <= 2000 && D + 1 <= 2000)
            {
                grid[D + 1][R + 1]++;
            }
        }
    }
}

