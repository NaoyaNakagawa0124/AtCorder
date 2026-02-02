using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long A = long.Parse(readline[0]);
        long B = long.Parse(readline[1]);

        Console.WriteLine(12 * A + B);
    }
}

