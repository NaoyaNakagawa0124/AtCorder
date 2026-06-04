using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int L  = int.Parse(readline[0]);
        int R = int.Parse(readline[1]);

        Console.Write(R - L + 1);
    }
}

