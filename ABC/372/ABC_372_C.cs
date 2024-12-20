using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        var input = Console.In;
        var firstLine = input.ReadLine().Split();
        int N = int.Parse(firstLine[0]);
        int Q = int.Parse(firstLine[1]);
        var S = new StringBuilder(input.ReadLine());

        // 文字列 ABC を探す際、O(N) で毎回探索すると O(NQ) となり非常に重いため、
        // 部分更新のみで影響のある箇所(最大3箇所)のチェックのみ行うことで O(Q) で処理可能。
        // 初期的に S 中の "ABC" 出現数をカウント
        int countABC = 0;
        for (int i = 0; i + 3 <= N; i++)
        {
            if (S[i] == 'A' && S[i + 1] == 'B' && S[i + 2] == 'C')
            {
                countABC++;
            }
        }

        // クエリ処理
        // 更新箇所 X_i に対し、X_i 付近で "ABC" となりうるインデックスは (X_i - 2), (X_i - 1), (X_i) の開始位置
        // ただしインデックスは 0-based で考えるなら X_i-1 が S の該当位置 (X_i は1-based)
        // "ABC" 判定関数を用意して更新前後で変化があるか比較する
        for (int _q = 0; _q < Q; _q++)
        {
            var line = input.ReadLine().Split();
            int X = int.Parse(line[0]);
            char C = line[1][0];

            // 更新前後で影響のある3箇所をチェック
            // 0-based インデックスに直す
            int pos = X - 1;

            // 影響を受ける可能性のある start インデックス群
            // start, start+1, start+2 が "ABC" となるかチェックするので
            // start は pos-2, pos-1, pos となりうる
            for (int start = pos - 2; start <= pos; start++)
            {
                if (start >= 0 && start + 2 < N)
                {
                    // 更新前に ABC だったら countABC を減らす
                    if (S[start] == 'A' && S[start + 1] == 'B' && S[start + 2] == 'C')
                    {
                        countABC--;
                    }
                }
            }

            // 文字更新
            S[pos] = C;

            // 更新後もう一度上記範囲でチェックして、新たに ABC があれば countABC++ する
            for (int start = pos - 2; start <= pos; start++)
            {
                if (start >= 0 && start + 2 < N)
                {
                    if (S[start] == 'A' && S[start + 1] == 'B' && S[start + 2] == 'C')
                    {
                        countABC++;
                    }
                }
            }

            Console.WriteLine(countABC);
        }
    }
}
