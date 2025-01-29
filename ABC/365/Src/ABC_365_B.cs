using System;
using System.Collections.Generic;

class Program
{
    public class Number
    {
        public int Value { get; set; }
        public int Index { get; set; }
    }

    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());
        string[] readLine = Console.ReadLine().Split(" ");
        
        // 数値リストの作成
        List<Number> numbers = new List<Number>();
        for (int i = 0; i < N; i++)
        {
            numbers.Add(new Number
            {
                Value = int.Parse(readLine[i]),
                Index = i + 1
            });
        }

        // 降順にソート（Valueの降順、同じValueならIndexの昇順）
        numbers.Sort((x, y) =>
        {
            int valueCompare = y.Value.CompareTo(x.Value);
            if (valueCompare != 0) return valueCompare;
            return x.Index.CompareTo(y.Index); // Indexの昇順
        });

        // 2番目に大きい要素のIndexを出力
        Console.WriteLine(numbers[1].Index);
    }
}
