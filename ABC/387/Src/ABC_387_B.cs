using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        int A = int.Parse(Console.ReadLine());
        int sum = 0;

        for(int i = 1; i < 10; i++)
        {
            for(int j = 1; j < 10; j++)
            {
                if(i * j != A)
                {
                    sum += i * j;
                }
            }
        }
        Console.WriteLine(sum);
        return 0;
    }
}
