using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        string readline = Console.ReadLine();
        int R = int.Parse(readline);
        Console.WriteLine(100 - R % 100);
        return 0;
    }
}
