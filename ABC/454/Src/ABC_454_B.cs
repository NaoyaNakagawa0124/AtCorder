using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]); 
        int M = int.Parse(readline[1]);

        int[] F = new int[M];

        readline = Console.ReadLine().Split();

        for(int i=0; i<readline.Length; i++)
        {
            int tmp = int.Parse(readline[i]);
            F[tmp - 1]++;
        }

        // Q1
        bool ans = true;
        for(int i=0; i<M; i++)
        {
            if(F[i] == 1 || F[i] == 0)
            {
            }
            else
            {
                ans = false;
            }
        }
        if(ans == true)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }

        // Q2
        ans = true;
        for(int i=0; i<M; i++)
        {
            if(F[i] == 0)
            {
                ans = false;
                break;
            }
        }
        if(ans == true)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

