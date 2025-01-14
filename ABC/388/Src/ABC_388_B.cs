using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] S = Console.ReadLine().Split();
        int N = int.Parse(S[0]);
        int D = int.Parse(S[1]);
        int[] snakeInitT = new int[N];
        int[] snakeInitL = new int[N];
        for (int i = 0; i < N; i++)
        {
            S = Console.ReadLine().Split();
            snakeInitT[i] = int.Parse(S[0]);
            snakeInitL[i] = int.Parse(S[1]);
        }


        int maxHeavy = 0;
        for(int i = 1; i <= D; i++)
        {
            maxHeavy = 0;
            for(int j = 0; j < N; j++)
            {
                if(snakeInitT[j] * (snakeInitL[j] + i) > maxHeavy)
                {
                    maxHeavy = snakeInitT[j] * (snakeInitL[j] + i);
                }
            }
            Console.WriteLine(maxHeavy);
        }
        return 0;
    }
}
