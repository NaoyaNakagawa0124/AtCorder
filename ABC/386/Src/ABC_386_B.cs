using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string readline = Console.ReadLine();

        int zeroCount = 0;

        int counter = 0;

        for(int i = 0; i < readline.Length; i++)
        {
            if(readline[i] == '0')
            {
                zeroCount++;
                counter++;
                if(zeroCount == 2)
                {
                    counter--;
                    zeroCount = 0;
                }
            }
            else
            {
                counter++;
                zeroCount = 0;
            }
        }
        Console.WriteLine(counter);
        return 0;
    }
}
