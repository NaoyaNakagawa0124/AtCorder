using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int D = int.Parse(readline[1]);

        int[] A = new int[1000001];
        int deleteTime = 0;
        readline = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            int num = int.Parse(readline[i]);
            A[num]++;
        }
        for (int i = 1; i <= 1000000; i++)
        {
            if (A[i] > 0)
            {
                int count = 0;
                if (i - D >= 0)
                {
                    if (A[i - D] > 0)
                    {
                        count += A[i - D];
                    }
                    1-5 3-7 5-3 7-2 9-3 11-5
                }
                if (i + D <= 1000000)
                {
                    if (A[i + D] > 0)
                    {
                        count += A[i + D];
                    }
                }
                if (count > 0)
                {
                    deleteTime += count;
                }
            }
        }
    }
}

