// 自分の書いたコードではタイムアウトだった
// これはChatGPTのもの
// 累積和を用いてやるらしい。誰が思いつくねん。
using System;

class Program
{
    static void Main()
    {
        // 日数 D の読み込み
        int D = int.Parse(Console.ReadLine());

        // 参加者数 N の読み込み
        int N = int.Parse(Console.ReadLine());

        // 差分配列の作成 (Dのみ使用、D+1の要素は不要)
        int[] dailyVisitorCounts = new int[D];

        // 各参加者の来場期間の読み込み
        for (int i = 0; i < N; i++)
        {
            string[] rangeInput = Console.ReadLine().Split();
            int L = int.Parse(rangeInput[0]) - 1; // 0-based indexに変換
            int R = int.Parse(rangeInput[1]) - 1; // Rも0-basedに変換

            // 差分の記録
            dailyVisitorCounts[L] += 1;       // L日目の開始
            if (R + 1 < D)                    // R+1日目が範囲内の場合のみ減少を記録
            {
                dailyVisitorCounts[R + 1] -= 1;
            }
        }

        // 累積和を計算して各日の来場者数を求める
        int currentVisitors = 0;
        for (int i = 0; i < D; i++)
        {
            currentVisitors += dailyVisitorCounts[i];
            Console.WriteLine(currentVisitors);
        }
    }
}

//     using System;
//     using System.Collections.Generic;

//     class Program
//     {
//         static int Main()
//         {
//             // 日付数(文字列)
//             string readLine = Console.ReadLine();
//             int numDays_int = int.Parse(readLine);

//             int[] dailyVisitorCounts = new int[numDays_int];

//             // 合計来場者数
//             readLine = Console.ReadLine();
//             int numParticipants_int = int.Parse(readLine);

//             string[] readLine_split = new string[2];

//             // 来場者の来場期間を格納
//             for(int i = 0; i < numParticipants_int; i++)
//             {
//                 readLine = Console.ReadLine();
//                 readLine_split = readLine.Split(" ");
//                 for(int j = int.Parse(readLine_split[0]) - 1; j < int.Parse(readLine_split[1]); j++)
//                 {
//                     dailyVisitorCounts[j]++;
//                 }
//             }
//             for(int i = 0; i < numDays_int; i++)
//             {
//                 Console.WriteLine(dailyVisitorCounts[i]);
//             }
//             return 0;
//         }
// }
