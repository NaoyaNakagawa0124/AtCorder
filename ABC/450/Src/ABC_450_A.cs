using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse((Console.ReadLine()));
        for(int i=N;i>=1;i--)
        {
            Console.Write(i);
            if(i>1)
            {
                Console.Write(",");
            }
        }
    }
}

