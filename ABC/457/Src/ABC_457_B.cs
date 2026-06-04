using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[][] A = new int[N][];
        for (int i = 0; i < N; i++)
        {
            var line = Console.ReadLine().Split();
            int L = int.Parse(line[0]);
            A[i] = new int[L];
            for (int j = 0; j < L; j++) A[i][j] = int.Parse(line[j + 1]);
        }
        var xy = Console.ReadLine().Split();
        int X = int.Parse(xy[0]);
        int Y = int.Parse(xy[1]);
        Console.WriteLine(A[X - 1][Y - 1]);
        
    }
}

