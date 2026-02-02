using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int K = int.Parse(readline[1]);
        long[] a = new long[N + 1];
        if(K > N)
        {
            Console.Write(1);
            return;
        }
        else
        {
            for(int i = 0; i < K; i++)
            {
                a[i] = 1;
            }
            a[K] = K;
            for(int i = K + 1; i <= N; i++)
            {
                a[i] = 2 * a[i - 1] - a[i - K - 1];
                if(a[i] < 0)
                {
                    a[i] = 2 * (a[i - 1] + 100000000) - a[i - K - 1];
                }
                if(a[i] > 1000000000)
                {
                    a[i] = a[i] % 1000000000;
                }
            }
        }
        Console.Write(a[N]);
    }
}

