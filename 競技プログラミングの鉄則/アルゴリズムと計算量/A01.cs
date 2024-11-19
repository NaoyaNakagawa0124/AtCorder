using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 最も基本的な標準入力の読み込み
        string sideLength_str = Console.ReadLine();
        int sideLength_int = int.Parse(sideLength_str);

        Console.WriteLine(sideLength_int * sideLength_int);
    }
}
