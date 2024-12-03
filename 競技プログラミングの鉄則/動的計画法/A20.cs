// Author: Nakagawa Naoya
// Date: 2024/12/4
// Comment: DP配列 dp[i][j] は、文字列𝑆の最初の𝑖文字と、文字列𝑇の最初の𝑗文字の最長共通部分列の長さを表す。← この考え出ないって・・・。

using System;

class Program
{
    static void Main()
    {
        // 入力の読み込み
        string S = Console.ReadLine();
        string T = Console.ReadLine();

        int n = S.Length;
        int m = T.Length;

        // DPテーブルを作成
        int[,] dp = new int[n + 1, m + 1];

        // DPの計算
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (S[i - 1] == T[j - 1]) // 文字が一致する場合
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else // 文字が一致しない場合
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        // 結果の出力
        Console.WriteLine(dp[n, m]);
    }
}
