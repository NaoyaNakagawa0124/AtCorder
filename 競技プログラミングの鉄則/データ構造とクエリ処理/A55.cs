using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int Q = int.Parse(Console.ReadLine());
        var queries = new List<string>(Q);
        for (int i = 0; i < Q; i++)
        {
            queries.Add(Console.ReadLine());
        }

        // ソートされたセット（SortedSet）
        var sortedSet = new SortedSet<long>();
        var output = new List<long>();

        foreach (var query in queries)
        {
            var parts = query.Split();
            int type = int.Parse(parts[0]);
            long x = long.Parse(parts[1]);

            if (type == 1)
            {
                // クエリ 1: カードを追加
                sortedSet.Add(x);
            }
            else if (type == 2)
            {
                // クエリ 2: カードを削除
                sortedSet.Remove(x);
            }
            else if (type == 3)
            {
                // クエリ 3: 条件を満たす最小値を検索
                // var result = sortedSet.GetViewBetween(x, long.MaxValue); // 元のコード
                var result = sortedSet.GetViewBetween(x, 1000000000); // 10^9 を上限に指定
                output.Add(result.Count > 0 ? result.Min : -1);
            }
        }

        // クエリ3の結果を出力
        Console.WriteLine(string.Join("\n", output));
    }
}
