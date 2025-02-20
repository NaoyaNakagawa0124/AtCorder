using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string S = Console.ReadLine();

        List<int> ones = new List<int>();
        for (int i = 0; i < N; i++)
        {
            if (S[i] == '1')
            {
                ones.Add(i);
            }
        }

        int k = ones.Count;
        int median = ones[k / 2]; 
        long moves = 0;

        for (int i = 0; i < k; i++)
        {
            int targetPos = median - (k / 2) + i; 
            moves += Math.Abs(ones[i] - targetPos);
        }

        Console.WriteLine(moves);
    }
}
