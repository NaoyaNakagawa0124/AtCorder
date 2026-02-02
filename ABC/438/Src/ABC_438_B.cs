using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();

        string N = Console.ReadLine();
        string M = Console.ReadLine();

        long min = 1000;

        for(int i = 0; i < N.Length - M.Length + 1; i++)
        {
            long ans = 0;
            for(int j = 0; j < M.Length; j++)
            {
                long N_substring = long.Parse(N[i + j].ToString()) + 10;
                long M_substring = long.Parse(M[j].ToString());
                long sub = (N_substring - M_substring) % 10;
                ans += sub;
            }
            if(ans < min)
            {
                min = ans;
            }
        }
        Console.WriteLine(min);
    }
}

