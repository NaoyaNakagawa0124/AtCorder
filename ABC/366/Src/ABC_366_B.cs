using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        int N = int.Parse(Console.ReadLine());
        int M = 0;
        string[] S = new string[N];
        for(int i = 0; i < N; i++)
        {
            S[i] = Console.ReadLine();
            if(S[i].Length > M)
            {
                M = S[i].Length;
            }
        }

        for(int i = 0; i < M; i++)
        {
            string tmp = "";
            for(int j = N - 1; j >= 0; j--)
            {
                if(i > S[j].Length - 1)
                {
                    tmp += "*";
                }
                else
                {
                    tmp += S[j][i];
                    Console.Write(tmp);
                    tmp = ""; 
                }
            }
            if(i != M - 1)
            {
                Console.WriteLine();
            }
        }
        return 0;
    }
}
