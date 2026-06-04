using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string readline = Console.ReadLine();
        long ans = 0;
        for(int i=0; i<readline.Length; i++)
        {
            if(readline[i] == 'C')
            {
                if(readline.Length - 1 - i >= i)
                {
                    ans+=i+1;
                }
                else
                {
                    ans+=readline.Length-i;
                }
            }
        }
        Console.Write(ans);
    }
}

