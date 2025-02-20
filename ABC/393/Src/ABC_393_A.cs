using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        string[] readline = Console.ReadLine().Split();
        if(readline[0] == "sick" && readline[1] == "sick")
        {
            Console.WriteLine("1");
        }
        else if(readline[0] == "sick" && readline[1] == "fine")
        {
            Console.WriteLine("2");
        }
        else if(readline[0] == "fine" && readline[1] == "sick")
        {
            Console.WriteLine("3");
        }
        else if(readline[0] == "fine" && readline[1] == "fine")
        {
            Console.WriteLine("4");
        }
        return 0;
    }
}
