using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int M = int.Parse(readline[0]);
        int D = int.Parse(readline[1]);

        if(M == 1)
        {
            if(D == 7)
            {
                Console.Write("Yes");
                return;
            }
        }

        if(M == 3 && D == 3)
        {
                Console.Write("Yes");
                return;
        }
        if(M == 5 && D == 5)
        {
                Console.Write("Yes");
                return;
        }
        if(M == 7 && D == 7)
        {
                Console.Write("Yes");
                return;
        }
        if(M == 9 && D == 9)
        {
                Console.Write("Yes");
                return;
        }

        Console.Write("No");
    }
}

