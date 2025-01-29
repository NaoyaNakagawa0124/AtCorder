using System;

class Program
{
    // 手を整数で表現する: R=0, P=1, S=2
    // Aoki が出す手(a) に対して:
    //    Takahashi は負けない2通りを選べる。
    //    - tieHand[a] は引き分けになる手
    //    - winHand[a] は勝利する手
    static int[] tieHand = new int[3];
    static int[] winHand = new int[3];

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string S = Console.ReadLine();

        // Aoki の手を 0,1,2 (R,P,S) に変換
        //  R -> 0, P -> 1, S -> 2
        int[] aoki = new int[N];
        for (int i = 0; i < N; i++)
        {
            switch (S[i])
            {
                case 'R': aoki[i] = 0; break;
                case 'P': aoki[i] = 1; break;
                case 'S': aoki[i] = 2; break;
            }
        }

        // 対応表を作る
        // Aoki=R(0) -> Takahashi: R(0)=引き分け, P(1)=勝ち
        // Aoki=P(1) -> Takahashi: P(1)=引き分け, S(2)=勝ち
        // Aoki=S(2) -> Takahashi: S(2)=引き分け, R(0)=勝ち
        tieHand[0] = 0;  // Aoki=R -> Taka=R で引き分け
        winHand[0] = 1;  // Aoki=R -> Taka=P で勝利

        tieHand[1] = 1;  // Aoki=P -> Taka=P で引き分け
        winHand[1] = 2;  // Aoki=P -> Taka=S で勝利

        tieHand[2] = 2;  // Aoki=S -> Taka=S で引き分け
        winHand[2] = 0;  // Aoki=S -> Taka=R で勝利

        // DP 配列を用意する
        // dp[i][m]: i回目(0-based) で Taka が手 m (0=R,1=P,2=S) を出したときの最大勝利数
        // ただし手 m を出せる(負けない)場合のみ有効
        // N が大きいので、i=0..N-1 全部の 2次元配列を取ると O(N*3) メモリ=60万程度はギリギリいけるが、
        // スペース節約のため「前の行(dpPrev)」と「今の行(dpNow)」だけで十分。
        int[] dpPrev = new int[3];
        int[] dpNow  = new int[3];

        // まず i=0 (最初のラウンド) を初期化
        // Takahashi が取りうる手は tieHand[aoki[0]] または winHand[aoki[0]]] の 2 通り
        // 最初はまだ「前の手と同じ」制約は存在しないので、とりうる2通りに対して値をセットする。
        for (int m = 0; m < 3; m++)
        {
            dpPrev[m] = -1; // -1 なら「その手はあり得ない(または未更新)」の意
        }

        int tie0 = tieHand[aoki[0]];
        int win0 = winHand[aoki[0]];
        dpPrev[tie0] = 0;                 // 引き分け
        dpPrev[win0] = 1;                 // 勝ち

        // i=1 から N-1 まで回す
        for (int i = 1; i < N; i++)
        {
            // まず dpNow をすべて -1 にクリア
            for (int m = 0; m < 3; m++)
            {
                dpNow[m] = -1;
            }

            // 今回取りうる手 (tie, win) を求める
            int tie = tieHand[aoki[i]];
            int win = winHand[aoki[i]];

            // m' (前回) と m (今回) が異なるなら遷移可能
            // dpPrev[m'] が -1 でない (すなわち有効) 場合に限り遷移
            // 遷移先 dpNow[m] = dpPrev[m'] + (今回勝つなら 1)
            // "今回勝つなら 1" は (m == win) のとき
            for (int mPrime = 0; mPrime < 3; mPrime++)
            {
                if (dpPrev[mPrime] < 0) continue; // 無効状態は飛ばす

                // tie
                if (tie != mPrime)  // 連続手が同じでなければ
                {
                    int candidate = dpPrev[mPrime] + 0;  // tie なので勝ち +0
                    dpNow[tie] = Math.Max(dpNow[tie], candidate);
                }

                // win
                if (win != mPrime)
                {
                    int candidate = dpPrev[mPrime] + 1;  // win なので勝ち +1
                    dpNow[win] = Math.Max(dpNow[win], candidate);
                }
            }

            // 今回の結果 dpNow を dpPrev にコピー
            Array.Copy(dpNow, dpPrev, 3);
        }

        // 最終的に dpPrev[0], dpPrev[1], dpPrev[2] の最大値が答え
        int ans = Math.Max(dpPrev[0], Math.Max(dpPrev[1], dpPrev[2]));
        Console.WriteLine(ans);
    }
}


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static int Main()
//     {
//         int N = int.Parse(Console.ReadLine());
//         string readLine = Console.ReadLine();

//         List<char> S_head = new List<char>(N);
//         List<char> S_tail = new List<char>(N);

//         for(int i = 0; i < N; i++)
//         {
//             S_head.Add(readLine[i]);
//             S_tail.Add(readLine[N - 1 - i]);
//         }

//         int head_winTimes = Cal_WinTimes(S_head);
//         int tail_winTimes = Cal_WinTimes(S_tail);

//         int winTimes = Math.Max(head_winTimes, tail_winTimes);
//         Console.WriteLine(winTimes);
//         return 0;
//     }

//     static int Cal_WinTimes(List<char> S)
//     {
//         int winTimes = 0;
//         int before_hand = 0;

//         for(int i = 0; i < S.Count; i++)
//         {
//             if(S[i] == 'R')
//             {
//                 // 前回の手がパーでなければパーを出して勝つ
//                 if(before_hand != 2)  
//                 {
//                     before_hand = 2;
//                     winTimes++;
//                 }
//                 else
//                 {
//                     before_hand = 1;  
//                 }
//             }
//             else if(S[i] == 'P')
//             {
//                 // 前回の手がチョキでなければチョキで勝つ
//                 if(before_hand != 3)  
//                 {
//                     before_hand = 3;
//                     winTimes++;
//                 }
//                 else
//                 {
//                     before_hand = 2;  
//                 }
//             }
//             else // S[i] == 'S'
//             {
//                 // 前回の手がグーでなければグーで勝つ
//                 if(before_hand != 1)  
//                 {
//                     before_hand = 1;
//                     winTimes++;
//                 }
//                 else
//                 {
//                     before_hand = 3;   
//                 }
//             }
//         }

//         return winTimes;
//     }
// }
