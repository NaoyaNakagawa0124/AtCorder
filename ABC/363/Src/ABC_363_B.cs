using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] readline = Console.ReadLine().Split();

        int N = int.Parse(readline[0]);
        int T = int.Parse(readline[1]);
        int P = int.Parse(readline[2]);

        int[] hair_count = new int[N];
        readline = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            hair_count[i] = int.Parse(readline[i]);
        }

        Array.Sort(hair_count);

        if(T - hair_count[N - P]<= 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine(T - hair_count[N - P]);
        }
        
        return 0;
    }
}
