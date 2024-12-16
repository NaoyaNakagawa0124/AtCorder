using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        string[] readline = Console.ReadLine().Split();
        long N = long.Parse(readline[0]);
        long X = long.Parse(readline[1]);
        long Y = long.Parse(readline[2]);

        bool judge = false;

        readline = Console.ReadLine().Split();
        int[] num = new int[N];
        for (int i = 0; i < N; i++)
        {
            num[i] = int.Parse(readline[i]);
        }

        // 最大値確認
        Console.WriteLine("最大値：" + num.Max());

        // 勝敗状態を求める
        bool[] enemyLose = canWin(num.Max(), X, Y);

        // 勝敗状態の確認
        for (int i = 0; i < enemyLose.Length; i++)
        {
            Console.WriteLine($"enemyLose[{i}] = {enemyLose[i]}");
        }

        // 各山の石の数に対する結果確認
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"山 {i + 1}: 石の数 {num[i]}, 結果 {enemyLose[num[i]]}");
            if (enemyLose[num[i]])
            {
                judge = !judge;
            }
        }

        // 結果の出力
        if (judge)
        {
            Console.WriteLine("First");
        }
        else
        {
            Console.WriteLine("Second");
        }
    }

    static bool[] canWin(long N, long A, long B)
    {
        // 石の個数ごとの勝敗状態を表す配列を用意
        bool[] enemyLose = new bool[N + 1];

        for (long i = 0; i <= N; i++)
        {
            // iがB個以上の場合
            if (i >= B && !enemyLose[i - B])
            {
                enemyLose[i] = true; // 後手を負け状態にできる
            }
            // iがA個以上の場合 (B未満の場合も考慮)
            else if (i >= A && !enemyLose[i - A])
            {
                enemyLose[i] = true; // 後手を負け状態にできる
            }
            else
            {
                enemyLose[i] = false; // どちらも成立しない場合
            }
        }

        return enemyLose;
    }
}
