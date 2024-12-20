using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] readline = Console.ReadLine().Split();

        if(readline[0] == "<")
        {
            if(readline[1] == "<")
            {
                if(readline[2] == "<")
                {
                    Console.WriteLine("B");
                }
                else
                {
                    Console.WriteLine("C");
                }
            }
            else
            {
                Console.WriteLine("A");
            }
        }
        else
        {
            if(readline[1] == "<")
            {
                Console.WriteLine("A");
            }
            else
            {
                if(readline[2] == ">")
                {
                    Console.WriteLine("B");
                }
                else
                {
                    Console.WriteLine("C");
                }
            }
        }
        return 0;
    }
}