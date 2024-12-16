using System;
using System.Linq;

class Program
{
    static int Main()
    {
        // 2つの整数を入力
        string[] readline = Console.ReadLine().Split();
        long N = long.Parse(readline[0]);
        long M = long.Parse(readline[1]);
        long B = long.Parse(readline[2]);

        readline = Console.ReadLine().Split();
        long sumN = 0;
        for(int i = 0; i < N; i++)
        {
            sumN += int.Parse(readline[i]);
        }

        readline = Console.ReadLine().Split();
        long sumM = 0;
        for(int i = 0; i < M; i++)
        {
            sumM += int.Parse(readline[i]);
        }
        Console.WriteLine(B * N * M + sumN * M + sumM * N);

        return 0;
    }
}
