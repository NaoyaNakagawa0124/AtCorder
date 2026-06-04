using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        long K = long.Parse(readline[1]);

        long[][] A = new long[N][];
        for (int i = 0; i < N; i++)
        {
            readline = Console.ReadLine().Split();
            int L = int.Parse(readline[0]);
            A[i] = new long[L];
            for (int j = 0; j < L; j++) A[i][j] = long.Parse(readline[j + 1]);
        }

        readline = Console.ReadLine().Split();
        long[] C = new long[N];
        for (int i = 0; i < N; i++) C[i] = long.Parse(readline[i]);

        long[] S = new long[N + 1];
        for (int i = 0; i < N; i++) S[i + 1] = S[i] + C[i] * A[i].Length;

        int idx = 0;
        while (S[idx + 1] < K) idx++;

        long pos = K - S[idx];
        long inA = (pos - 1) % A[idx].Length;
        Console.WriteLine(A[idx][inA]);
    }
}
