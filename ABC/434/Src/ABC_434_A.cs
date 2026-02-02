using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long W = long.Parse(readline[0]) * 1000;
        long B = long.Parse(readline[1]);
        Console.WriteLine(W / B + 1);
    }
}

