using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int M = int.Parse(readline[1]);
        int[] A = new int[M];

        for(int i=0; i<N; i++)
        {
            readline = Console.ReadLine().Split();
            int last_year = int.Parse(readline[0]);
            int this_year = int.Parse(readline[1]);

            A[last_year-1]--;
            A[this_year-1]++;
        }
        for(int i=0; i<M;i++)
        {
            Console.WriteLine(A[i]);
        }

    }
}

