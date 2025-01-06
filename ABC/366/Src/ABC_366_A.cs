using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] S = Console.ReadLine().Split();
        int N = int.Parse(S[0]);
        int T = int.Parse(S[1]);
        int A = int.Parse(S[2]);

        if(N - (T + A) > Math.Abs(T - A))
        {
            Console.Write("No");
        }
        else
        {
            Console.Write("Yes");
        }

        return 0;
    }
}
