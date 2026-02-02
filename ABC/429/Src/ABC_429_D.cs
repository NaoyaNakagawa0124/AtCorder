using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        // 変数の用意
        long N = long.Parse(readline[0]);
        long M = long.Parse(readline[1]);
        long C = long.Parse(readline[2]);
        long[] A = new long[N];

        // 地点iにいる人の数
        long[] num_man = new long[N];

        // 重複無しのリスト生成(これによって人がいない探索しなくてよくなる)
        var exist_position = new HashSet<long>();
        for (long i = 0; i < N; i++)
        {
            A[i] = long.Parse(Console.ReadLine());
            num_man[A[i]]++;
            exist_position.Add(A[i]);
        }

        // 地点の圧縮
        long[,] position = new long[N, C];

        // この操作でM => N へと 1周の長さを圧縮
        // position[i]には圧縮後の地点iにいる人の数が入る +1, +1, のような加算行列をイメージするといい。
        foreach (long i in exist_position)
        {
            position[i] = num_man[i];
        }
        
    }
}

