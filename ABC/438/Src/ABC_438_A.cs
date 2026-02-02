using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long D = long.Parse(readline[0]);
        long F = long.Parse(readline[1]);

        long sub = D - F;

        long sub_7 = sub % 7;

        Console.WriteLine(7 - sub_7);
    }
}

