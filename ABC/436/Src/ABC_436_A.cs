using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long N = long.Parse(readline[0]);

        string s = Console.ReadLine();
        
        while(N - s.Length > 0)
        {
            Console.Write("o");
            N--;
        }
        Console.WriteLine(s);
    }
}

