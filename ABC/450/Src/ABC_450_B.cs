using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] grid = new int[N + 1, N + 1];

        for(int i=0; i <N + 1; i++)
        {
            for(int j=0; j<N + 1; j++)
            {
                grid[i,j] = 0;
            }
        }

        for(int i = 0; i < N - 1; i++)
        {
            string[] readline = Console.ReadLine().Split();
            for(int j = 0; j < readline.Length; j++)
            {
                grid[i+1, i+2+j] = int.Parse(readline[j]);
            }
        }

        for(int i = 1; i < N+1; i++)
        {
            // 先頭と中間地点に注目！
            for(int j=i+1; j<N+1; j++)
            {
                // ここで最後の点
                for(int k=j+1; k<N+1; k++)
                {
                    if(grid[i,j] + grid[j,k] < grid[i,k])
                    {
                        Console.Write("Yes");
                        return;
                    }
                }
            }
        }
        Console.Write("No");
        return;
    }
}

