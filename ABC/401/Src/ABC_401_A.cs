using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int S = int.Parse(Console.ReadLine());
        if(200 <= S && S <= 299)
        {
            Console.WriteLine("Success");
        }
        else
        {
            Console.WriteLine("Failure");
        }
    }
}

