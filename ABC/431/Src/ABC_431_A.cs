using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long H = long.Parse(readline[0]);
        long B = long.Parse(readline[1]);
        if (H - B > 0)
        {
            Console.WriteLine(H - B);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}

