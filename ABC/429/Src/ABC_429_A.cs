using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int M = int.Parse(readline[1]);

        for (int i = 0; i < N; i++)
        {
            if (i < M)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Too Many Requests");
            }
        }
    }
}

