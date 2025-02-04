using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 入力読み込み
        // 1行目： N, X, Y
        var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int N = tokens[0], X = tokens[1], Y = tokens[2];

        // 料理の情報を格納
        int[] A = new int[N]; // 料理 i の甘さ
        int[] B = new int[N]; // 料理 i のしょっぱさ
        for (int i = 0; i < N; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            A[i] = ab[0];
            B[i] = ab[1];
        }

        // dp[k][s] : 料理を k 品選んで、累計甘さが s になったときの最小の累計しょっぱさ
        // s の範囲は 0 <= s <= X
        // ※ 値が INF (十分大きな数) の場合は、その状態を作れないことを表す
        const int INF = 1000000000;
        int[,] dp = new int[N + 1, X + 1];
        for (int k = 0; k <= N; k++)
        {
            for (int s = 0; s <= X; s++)
            {
                dp[k, s] = INF;
            }
        }
        dp[0, 0] = 0;  // 料理を 0 品選んだとき、甘さも塩っぱさも 0

        // 各料理について DP を更新
        for (int i = 0; i < N; i++)
        {
            int a = A[i];
            int b = B[i];

            // 同じ料理を複数回使えないよう、k を大きいほうから更新する
            for (int k = N - 1; k >= 0; k--)
            {
                for (int s = 0; s <= X; s++)
                {
                    // その状態が存在しないならスキップ
                    if (dp[k, s] == INF) continue;

                    int ns = s + a;              // 新しい累計甘さ
                    int nt = dp[k, s] + b;         // 新しい累計しょっぱさ

                    // 新しい状態が制約内なら更新
                    if (ns <= X && nt <= Y)
                    {
                        dp[k + 1, ns] = Math.Min(dp[k + 1, ns], nt);
                    }
                }
            }
        }

        // 安全に食べられる料理の最大個数 safeCount を求める
        // safeCount とは、料理を safeCount 品食べたとき、
        // どんな累計甘さ (0 <= s <= X) でも累計しょっぱさが Y 以下となる状態が存在する最大の数
        int safeCount = 0;
        for (int k = 0; k <= N; k++)
        {
            bool possible = false;
            for (int s = 0; s <= X; s++)
            {
                if (dp[k, s] <= Y)
                {
                    possible = true;
                    break;
                }
            }
            if (possible) safeCount = k;
        }

        // すぬけ君は、安全に食べられた後、さらに 1 品だけ追加で食べられる
        // （その 1 品がしきい値を超えても、食べ始めたらそこで止まるため）
        int answer = (safeCount < N) ? safeCount + 1 : safeCount;

        Console.WriteLine(answer);
    }
}
