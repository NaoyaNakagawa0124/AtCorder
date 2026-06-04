using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        long K = long.Parse(readline[1]);

        long[] A = new long[N];
        readline = Console.ReadLine().Split();
        for (int i = 0; i < N; i++) A[i] = long.Parse(readline[i]);

        long lo = long.MaxValue;
        for (int i = 0; i < N; i++) if (A[i] < lo) lo = A[i];
        long hi = (long)2e18;

        while (lo < hi)
        {
            long mid = lo + (hi - lo + 1) / 2;
            if (Check(mid, A, K)) lo = mid;
            else hi = mid - 1;
        }

        Console.WriteLine(lo);
    }

    static bool Check(long X, long[] A, long K)
    {
        long needed = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] >= X) continue;
            long diff = X - A[i];
            long iVal = i + 1;
            long ops = (diff + iVal - 1) / iVal;
            needed += ops;
            if (needed > K) return false;
        }
        return needed <= K;
    }
}
