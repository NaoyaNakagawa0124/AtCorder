using System;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());
        int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // DP配列の初期化（2次元配列）
        int[,] dp = new int[N + 1, N + 1];

        // 最下段（N段目）の初期化
        for (int j = 0; j < N; j++)
        {
            dp[N, j] = A[j];
        }

        // DPの更新（逆順に計算）
        for (int i = N - 1; i >= 1; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if ((N - i) % 2 == 1) // 太郎君のターン（最大化）
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i + 1, j + 1]);
                }
                else // 次郎君のターン（最小化）
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i + 1, j + 1]);
                }
            }
        }

        // 答えの出力
        Console.WriteLine(dp[1, 0]);
    }
}
