// Author: Nakagawa Naoya
// Date: 2024/12/5
// Comment: こんなの難しすぎるやろ！Bitをそのまま使うのはやったことないから難しかったけど10の累乗みたいな感じで計算するのは思いついたから発想自体は似てた。
// 問題の分類としては集合被覆という問題で、これもDPが有効みたいなのでこれから覚えておく！！！
using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] couponMask = new int[N];

        string[] line = Console.ReadLine().Split();

        for (int i = 0; i < N; i++)
        {
            couponMask = int.Parse(line[i]);
        }

        int[,] longestSubsequence = new int[N , N];
        for(int i = 0; i < N; i++)
        {
            longestSubsequence[i , j] =  1;
        }

        for(int i = 1; i < N; i++)
        {
            for(int j = 1; j < N; j++)
            {
                longestSubsequence[i, j] = longestSubsequence[i - 1, j];
                if(i < j && )
            }
        }
    }
}
