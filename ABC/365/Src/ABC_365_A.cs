using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        int Y = int.Parse(Console.ReadLine());
        if(Y % 400 == 0)
        {
            Console.WriteLine("366");
        }
        else
        {
            if(Y % 100 == 0)
            {
                Console.WriteLine("365");
            }
            else
            {
                if(Y % 4 == 0)
                {
                    Console.WriteLine("366");
                }else
                {
                    Console.WriteLine("365");
                }
            }
        }
        return 0;
    }
}
