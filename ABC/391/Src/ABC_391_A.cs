using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string direction = Console.ReadLine();
        if(direction == "N")
        {
            Console.WriteLine("S");
        }
        else if(direction == "S")
        {
            Console.WriteLine("N");
        }
        else if(direction == "E")
        {
            Console.WriteLine("W");
        }
        else if(direction == "W")
        {
            Console.WriteLine("E");
        }
        else if(direction == "NE")
        {
            Console.WriteLine("SW");
        }
        else if(direction == "NW")
        {
            Console.WriteLine("SE");
        }
        else if(direction == "SE")
        {
            Console.WriteLine("NW");
        }
        else if(direction == "SW")
        {
            Console.WriteLine("NE");
        }
        return 0;
    }
}
