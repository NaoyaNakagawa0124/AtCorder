// Author: Nakagawa Naoya
// Date: 2024/12/5
// Comment: こんなの難しすぎるやろ！Bitをそのまま使うのはやったことないから難しかったけど10の累乗みたいな感じで計算するのは思いついたから発想自体は似てた。
// 問題の分類としては集合被覆という問題で、これもDPが有効みたいなのでこれから覚えておく！！！
using System;

class Program
{
    static void Main()
    {
        string[] nm = Console.ReadLine().Split();
        int N = int.Parse(nm[0]);
        int M = int.Parse(nm[1]);

        int[] couponMask = new int[M];
        for (int i = 0; i < M; i++)
        {
            string[] line = Console.ReadLine().Split();
            int mask = 0;
            for (int j = 0; j < N; j++)
            {
                int a = int.Parse(line[j]);
                if (a == 1)
                {
                    // j番目の品物をカバー
                    mask |= (1 << j);
                }
            }
            couponMask[i] = mask;
        }

        // dp[mask]: maskで表される品物集合をカバーするための最小クーポン数
        // 初期値として大きな値 (M+1) などをセット
        int fullMask = (1 << N) - 1;
        int[] dp = new int[1 << N];
        for (int i = 1; i <= fullMask; i++)
        {
            dp[i] = M + 1; // 到達不能を表す大きな値
        }
        dp[0] = 0; // 何もカバーしていない状態はクーポン使用数0

        // 状態遷移
        for (int mask = 0; mask <= fullMask; mask++)
        {
            if (dp[mask] > M) continue; // 既に到達不能ならスキップ

            for (int i = 0; i < M; i++)
            {
                int newMask = mask | couponMask[i];
                if (dp[newMask] > dp[mask] + 1)
                {
                    dp[newMask] = dp[mask] + 1;
                }
            }
        }

        int ans = dp[fullMask];
        if (ans > M) ans = -1; // 更新されていない場合は-1

        Console.WriteLine(ans);
    }
}
