// 価格に従って商品を降順にソートする

// 降順にソートされた結果:
// 価格: 3000, 商品名: 商品A
// 価格: 2500, 商品名: 商品C
// 価格: 1500, 商品名: 商品B
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // カスタムコンパレータを使用して降順にソート
        SortedList<int, string> sortedList = new SortedList<int, string>(
            Comparer<int>.Create((x, y) => y.CompareTo(x))
        );

        // 商品を追加
        sortedList.Add(3000, "商品A");
        sortedList.Add(1500, "商品B");
        sortedList.Add(2500, "商品C");

        // 結果を出力
        Console.WriteLine("降順にソートされた結果:");
        foreach (var item in sortedList)
        {
            Console.WriteLine($"価格: {item.Key}, 商品名: {item.Value}");
        }
    }
}

// 価格に従って商品を昇順にソートする

// 昇順にソートされた結果:
// 価格: 1500, 商品名: 商品B
// 価格: 2500, 商品名: 商品C
// 価格: 3000, 商品名: 商品A

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // SortedListの初期化（キー: 商品価格、値: 商品名）
        SortedList<int, string> sortedList = new SortedList<int, string>();

        // 商品を追加
        sortedList.Add(3000, "商品A");
        sortedList.Add(1500, "商品B");
        sortedList.Add(2500, "商品C");

        // キー順に自動ソートされている
        Console.WriteLine("キーでソートされた結果:");
        foreach (var item in sortedList)
        {
            Console.WriteLine($"価格: {item.Key}, 商品名: {item.Value}");
        }
    }
}

