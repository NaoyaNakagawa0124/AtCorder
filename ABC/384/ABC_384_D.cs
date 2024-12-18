using System;
using System.Collections.Generic;
class Program
{
    static int Main()
    {

        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]); 
        int S = int.Parse(readline[1]);

        readline = Console.ReadLine().Split();

        // 2次元配列を作成
        int[,] grid = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            grid[i, i] = int.Parse(readline[i]);
        }
        return 0;
    }
}