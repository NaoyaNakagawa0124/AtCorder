using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int H = int.Parse(readline[0]);
        int W = int.Parse(readline[1]);

        for(int i=0; i<H; i++)
        {
            for(int j=0; j<W; j++)
            {
                if(i==0 || j==0 || i==H-1 || j==W-1)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}

