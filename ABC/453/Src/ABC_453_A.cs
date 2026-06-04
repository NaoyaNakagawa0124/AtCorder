using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string readline = Console.ReadLine();
        readline = Console.ReadLine();
        int i = 0;

        while(i < readline.Length && readline[i] == 'o')
        {
            i++;
        }
        for(int j=i; j< readline.Length; j++)
        {
            Console.Write(readline[j]);
        }
        return;
    }
}

