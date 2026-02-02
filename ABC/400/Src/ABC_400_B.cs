using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long N = long.Parse(readline[0]);
        long M = long.Parse(readline[1]);

        long[] a = new long[M + 1];
        long sum = 1;
        a[0] = 1;
        for(int i = 1; i < M + 1; i++)
        {
            a[i] = a[i - 1] * N;
            if(a[i] > 1000000000)
            {
                Console.WriteLine("inf");
                return;
            }
            sum += a[i];
            if(sum > 1000000000)
            {
                Console.WriteLine("inf");
                return;
            }
        }
        Console.WriteLine(sum);
    }
}

