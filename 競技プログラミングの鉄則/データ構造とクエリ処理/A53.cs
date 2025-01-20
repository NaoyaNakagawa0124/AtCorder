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

        // 優先度付きキュー（最小ヒープ）
        var minHeap = new SortedSet<(int price, int id)>();
        int idCounter = 0; // 各商品のユニークIDを管理するカウンタ
        var output = new List<int>(); // クエリ2の出力を格納

        foreach (var query in queries)
        {
            var parts = query.Split();
            int type = int.Parse(parts[0]);

            if (type == 1)
            {
                // クエリ1: 商品を追加
                int price = int.Parse(parts[1]);
                minHeap.Add((price, idCounter));
                idCounter++;
            }
            else if (type == 2)
            {
                // クエリ2: 最小価格を出力
                output.Add(minHeap.Min.price);
            }
            else if (type == 3)
            {
                // クエリ3: 最も安い商品を1つ売る
                minHeap.Remove(minHeap.Min);
            }
        }

        // クエリ2の結果を出力
        Console.WriteLine(string.Join("\n", output));
    }
}
