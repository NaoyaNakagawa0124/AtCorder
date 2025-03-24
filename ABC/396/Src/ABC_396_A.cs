using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] S = Console.ReadLine().Split(" ");

        int[] A = new int[N];
        for(int i = 0; i < N; i++)
        {
            A[i] = int.Parse(S[i]);
        }

        int duplic = 1;

        for(int i = 0; i < N - 1; i++)
        {
            if(A[i] == A[i + 1])
            {
                duplic++;
            }
            else
            {
                duplic = 1;
            }
            if(duplic == 3)
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");
    }
}

