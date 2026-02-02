using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int X = int.Parse(readline[0]);
        readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int[] W = new int[N];
        readline = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            W[i] = int.Parse(readline[i]);
        }
        readline = Console.ReadLine().Split();
        int Q = int.Parse(readline[0]);
        bool[] P = new bool[Q];
        for (int i = 0; i < Q; i++)
        {
            P[i] = false;
        }
        for (int i = 0; i < Q; i++)
        {
            readline = Console.ReadLine().Split();
            int tmp = int.Parse(readline[0]);
            if (P[tmp - 1] == false)
            {
                P[tmp - 1] = true;
                X += W[tmp - 1];
            }
            else
            {
                P[tmp - 1] = false;
                X -= W[tmp - 1];
            }
            Console.WriteLine(X);
        }
    }
}

