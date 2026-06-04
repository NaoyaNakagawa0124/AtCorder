using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        Console.Write(Math.Pow(2, N) - 2*N);
    }
}

