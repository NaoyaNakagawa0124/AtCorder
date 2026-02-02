using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        if(400 % N == 0)
        {
            Console.WriteLine(400 / N);
        }
        else
        {
            Console.WriteLine(-1);
        }
    }
}

