using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int X = int.Parse(readline[0]);
        int Y = int.Parse(readline[1]);
        for(int i=0; i<Y; i++)
        {
            X = X*2;
        }
        Console.WriteLine(X);
    }
}

