using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string readline = Console.ReadLine();
        long N = long.Parse(readline);
        readline = Console.ReadLine();
        
        long[] prevN = new long[N + 1];
        long[] nextN = new long[N + 1];

        prevN[0] = none;
        nextN[0] = none;

        for (int i = 0; i <= N; i++)
        {
            if(readline[i] == 'L')
            {
                long tmp = prevN[i - 1];
                prevN[i - 1] = i;
                nextN[i] = tmp;
                if(tmp != none)
                {
                    
                }
            }
        }


    }
}

