using System;

class Program
{
    static void Main()
    {
        // 1行目：N と M
        string[] first = Console.ReadLine().Split();
        int N = int.Parse(first[0]);
        int M = int.Parse(first[1]);

        // 差分配列 (1-indexed) ―― 長さは N+2 でガード
        int[] diff = new int[N + 2];

        // M 行の区間 [L, R] を読み込んで差分配列へ反映
        for (int i = 0; i < M; i++)
        {
            string[] parts = Console.ReadLine().Split();
            int L = int.Parse(parts[0]);
            int R = int.Parse(parts[1]);

            diff[L]     += 1;   // 区間開始
            diff[R + 1] -= 1;   // 区間終了の次で打ち消し
        }

        // 累積しながら最小重なり数 (= 壊す砲台の最小個数) を求める
        int cur = 0;
        int answer = int.MaxValue;
        for (int j = 1; j <= N; j++)
        {
            cur += diff[j];
            if (cur < answer) answer = cur;
        }

        Console.WriteLine(answer);
    }
}
