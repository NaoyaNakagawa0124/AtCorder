using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        readline = Console.ReadLine().Split();

        double lp = 0.5;
        int count = 0;

        for(int i=0; i<readline.Length; i++)
        {
            if(lp > 0)
            {
                lp = lp - int.Parse(readline[i]);
                if(lp < 0)
                {
                    count++;
                }
            }
            else
            {
                lp = lp + int.Parse(readline[i]);
                if(lp > 0)
                {
                    count++;
                }
            }
        }
        Console.Write(count);
    }
}

