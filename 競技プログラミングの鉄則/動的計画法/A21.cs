// Author: Nakagawa Naoya
// Date: 2024/12/5
// Comment: だから難しいって・・・・・・・・。どうやったらその考えできるんだ・・・・・。でも大事なのは動的計画法の肝である大きな問題をどうやって細かい問題に細分化できるか！！！！
         // これを基準に試行錯誤すべし！！！
using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] P = new int[N];
        int[] A = new int[N];
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            P[i] = int.Parse(input[0]) - 1; // 0-indexed
            A[i] = int.Parse(input[1]);
        }

        int[,] dp = new int[N + 1, N + 1];

        // len: 残っている区間の長さ
        for (int len = 1; len <= N; len++)
        {
            for (int l = 0; l + len <= N; l++)
            {
                int r = l + len;

                // 左端を取る場合
                int scoreLeft = 0;
                if (l + 1 <= N)
                {
                    scoreLeft = dp[l + 1, r];
                    if (P[l] >= l + 1 && P[l] < r)
                    {
                        scoreLeft += A[l];
                    }
                    dp[l, r] = Math.Max(dp[l, r], scoreLeft);
                }

                // 右端を取る場合
                int scoreRight = 0;
                if (r - 1 >= 0)
                {
                    scoreRight = dp[l, r - 1];
                    if (P[r - 1] >= l && P[r - 1] <= r - 1)
                    {
                        scoreRight += A[r - 1];
                    }
                    dp[l, r] = Math.Max(dp[l, r], scoreRight);
                }
            }
        }

        Console.WriteLine(dp[0, N]);
    }
}
