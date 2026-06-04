using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        string[] A = Console.ReadLine().Split();
        readline = Console.ReadLine().Split();
        int X = int.Parse(readline[0]);
        Console.Write(A[X-1]);
    
    }
}

