// using System;
// using System.Collections.Generic;
// using System.Linq; // ← SortやLINQに必要

// class Program
// {
//     static void Main()
//     {
//         string[] readline = Console.ReadLine().Split();
//         int N = int.Parse(readline[0]);

//         int[] W = new int[N];
//         long[] H = new long[N];
//         long[] B = new long[N];

//         long ans = 0;

//         for (int i = 0; i < N; i++)
//         {
//             readline = Console.ReadLine().Split();
//             W[i] = int.Parse(readline[0]);
//             H[i] = long.Parse(readline[1]);
//             B[i] = long.Parse(readline[2]);
//         }

//         // いったんここでW[i]を基点にソート
//         var list = new List<(int W, long H, long B)>();
//         for (int i = 0; i < N; i++)
//         {
//             list.Add((W[i], H[i], B[i]));
//         }
//         list.Sort((a, b) => a.W.CompareTo(b.W));

//         // 一旦すべて体の場合の値を求めておく
//         for (int i = 0; i < N; i++)
//         {
//             ans += B[i];
//         }

//         // ここではすべてのパーツの重さの合計の半分を頭の重さの最大値として定義しておく
//         int limit = 0;
//         for (int i = 0; i < N; i++)
//         {
//             limit += W[i];
//         }

//         var headList = new HashSet<long>(); // 取りうる頭の重さがすべて入った重複無しのリスト
//         long[] headHavy = new long[limit * 2]; // 任意の重さnでの最大幸福値
//         long max = 0; // 最大値の初期化
//         var toAdd = new List<long>();

//         // limitは合計の重さの半分まで
//         limit = limit / 2;

//         // ここから実際の計算　W[i]が小さいものから順番に頭にしていくが、頭の大きさごとに嬉しさの最大値を求める
//         for (int i = 0; i < N; i++)
//         {
//             long happiness = 0; // 体から頭にパーツを変更したときに幸せ差分
//             happiness = H[i] - B[i];
//             // 頭にすることで不幸せになるならそもそも処理しなくていい
//             if (happiness > 0)
//             {
//                 // 既存の重さすべてに対して現在探索中のパーツを頭にした際の幸福度を加算していく
//                 foreach (var item in headList)
//                 {
//                     // 既存の重さに操作中のパーツの重さを加えてもリミットを超えない　かつ　既存の重さ + 今のパーツの重さでの幸福度がその重さでの最大値 の場合にその重さでの幸福度の値を更新
//                     if (item + W[i] <= limit && headHavy[item] + happiness > headHavy[item + W[i]])
//                     {
//                         headHavy[item + W[i]] = headHavy[item] + happiness;
//                         toAdd.Add(item + W[i]);
//                         if (max < headHavy[item + W[i]])
//                         {
//                             max = headHavy[item + W[i]];
//                         }
//                     }
//                 }

//                 // foreach の外で追加
//                 foreach (var x in toAdd)
//                 {
//                     headList.Add(x);
//                 }
//                 toAdd.Clear();

//                 // その後にこのパーツ単体での比較
//                 if (happiness > headHavy[W[i]] && W[i] <= limit)
//                 {
//                     headHavy[W[i]] = happiness;
//                     headList.Add(W[i]);
//                     if (max < headHavy[W[i]])
//                     {
//                         max = headHavy[W[i]];
//                     }
//                 }
//             }
//         }
//         Console.WriteLine(ans + max);
//     }
// }


using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);

        var parts = new (int w, long h, long b)[N];
        long baseHappiness = 0; // すべて体にした場合の嬉しさ
        int totalWeight = 0;

        for (int i = 0; i < N; i++)
        {
            input = Console.ReadLine().Split();
            int w = int.Parse(input[0]);
            long h = long.Parse(input[1]);
            long b = long.Parse(input[2]);
            
            parts[i] = (w, h, b);
            baseHappiness += b;
            totalWeight += w;
        }

        // 頭の重さの上限
        int limit = totalWeight / 2;

        // DP配列: dp[w] = 頭の重さがちょうどwのときの「嬉しさ増分」の最大値
        long[] dp = new long[limit + 1];
        
        // 初期化: 到達不可能な状態を表す
        for (int i = 0; i <= limit; i++)
        {
            dp[i] = long.MinValue / 2; // オーバーフロー防止
        }
        dp[0] = 0; // 何も頭にしない状態

        // 各部品について処理
        for (int i = 0; i < N; i++)
        {
            int w = parts[i].w;
            long h = parts[i].h;
            long b = parts[i].b;
            long gain = h - b; // 体→頭への変更による嬉しさの変化

            // 嬉しさが増える場合のみ検討
            if (gain > 0)
            {
                // 後ろから更新（ナップサック問題の標準パターン）
                for (int prevW = limit - w; prevW >= 0; prevW--)
                {
                    if (dp[prevW] > long.MinValue / 2) // 到達可能な状態のみ
                    {
                        int newW = prevW + w;
                        dp[newW] = Math.Max(dp[newW], dp[prevW] + gain);
                    }
                }
            }
        }

        // 頭の重さ ≤ limit の範囲で最大値を探す
        long maxGain = 0;
        for (int w = 0; w <= limit; w++)
        {
            if (dp[w] > long.MinValue / 2)
            {
                maxGain = Math.Max(maxGain, dp[w]);
            }
        }

        Console.WriteLine(baseHappiness + maxGain);
    }
}