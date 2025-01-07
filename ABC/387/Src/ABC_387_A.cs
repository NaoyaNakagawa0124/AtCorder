using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] readline = Console.ReadLine().Split();
        int A = int.Parse(readline[0]);
        int B = int.Parse(readline[1]);

        Console.WriteLine((A + B) * (A + B));
        return 0;
    }
}
