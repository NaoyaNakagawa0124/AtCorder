using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] x = new int[3];
        int[] y = new int[3];
        for(int i = 0; i < 3; i++)
        {
            string[] readline = Console.ReadLine().Split();
            x[i] = int.Parse(readline[0]);
            y[i] = int.Parse(readline[1]);
        }

        int AC = (x[0] - x[2]) * (x[0] - x[2]) + (y[0] - y[2]) * (y[0] - y[2]);
        int BC = (x[1] - x[2]) * (x[1] - x[2]) + (y[1] - y[2]) * (y[1] - y[2]);
        int AB = (x[0] - x[1]) * (x[0] - x[1]) + (y[0] - y[1]) * (y[0] - y[1]);

        if(AB + BC == AC)
        {
            Console.WriteLine("Yes");
        }
        else if(AB + AC == BC)
        {
            Console.WriteLine("Yes");
        }
        else if(BC + AC == AB)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

