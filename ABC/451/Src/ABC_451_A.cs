using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string readline = Console.ReadLine();
        if(readline.Length % 5 == 0)
        {
            Console.Write("Yes");
        }
        else
        {
            Console.Write("No");
        }
    }
}

