using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string readline = Console.ReadLine();
        int X = int.Parse(readline);
        if(3<= X && X<=18)
        {
            Console.Write("Yes");
        }
        else
        {
            Console.Write("No");
        }
    }
}

