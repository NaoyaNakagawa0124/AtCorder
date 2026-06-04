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
            int tmp=0;
            if(i-1>=0)
            {
                tmp++;
            }
            if(i+1<H)
            {
                tmp++;
            }
            int log = tmp;
            for(int j=0; j<W; j++)
            {
                tmp = log;
                if(j-1>=0)
                {
                    tmp++;
                }
                if(j+1<W)
                {
                    tmp++;
                }
                Console.Write(tmp);
                if(j!=W-1)
                {
                    Console.Write(" ");
                }
            }
            if(i!=H-1)
            {
                Console.WriteLine();
            }
        }
    }
}

