using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        long N = long.Parse(s);
        long[,] a = new long[N, N];
        a[0, (N - 1) / 2] = 1;
        long r = 0;
        long c = (N - 1) / 2;
        long k = 1;
        
        for(int i = 1; i < N * N; i++)
        {
            long left  = 0;
            if(r - 1 < 0)
            {
                left = r - 1 + N;
            }
            else
            {
                left = (r - 1) % N;
            }
            if(a[left, (c + 1) % N] == 0)
            {
                a[left % N, (c + 1) % N] = k + 1;
                r = left;
                c = (c + 1) % N;
            }
            else
            {
                a[(r + 1) % N, c] = k + 1;
                r = (r + 1) % N;
            }
            k++;
        }
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

