using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int M = int.Parse(readline[1]);
        int[] A = new int[N];
        int sum = 0;
        readline = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(readline[i]);
            sum += A[i];
        }
        for (int i = 0; i < N; i++)
        {
            if (sum - A[i] == M)
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");
        return;
    }
}

