// Author: Nakagawa Naoya
// Date: 2024/12/9
// Comment: これもめっちゃ難しいな・・・・・。コードを見ても正直よくわからないくらい難しいのが現状。
// 問題の分類としては集合被覆という問題で、これもDPが有効みたいなのでこれから覚えておく！！！

using System;

class Program
{
    static void Main()
    {
        // 入力の読み込み
        int N = int.Parse(Console.ReadLine());
        string[] line = Console.ReadLine().Split();
        int[] A = new int[N];
        for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(line[i]);
        }

        // dp[i]: A[i]を末尾とするLISの長さ
        int[] dp = new int[N];
        for (int i = 0; i < N; i++)
        {
            dp[i] = 1; // 各要素自身がLIS
        }

        for (int i = 1; i < N; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (A[j] < A[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        // dp配列の最大値がLISの長さ
        int lisLength = 0;
        for (int i = 0; i < N; i++)
        {
            if (dp[i] > lisLength)
            {
                lisLength = dp[i];
            }
        }

        Console.WriteLine(lisLength);
    }
}
