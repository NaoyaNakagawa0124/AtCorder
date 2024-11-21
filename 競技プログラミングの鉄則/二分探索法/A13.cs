// 二分探索をどのように使用するかという考え方自体は合っていた。
// だが、どのように二分探索が回るか、その結果最終的に二分探索がどこで終了するかのイメージがまだまだ足りていない

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 最初の入力を取得（NとK）
        string[] inputs = Console.ReadLine().Split();
        int N = int.Parse(inputs[0]);
        long K = long.Parse(inputs[1]);

        // 配列の取得
        long[] candidateNumbers = Console.ReadLine().Split().Select(long.Parse).ToArray();

        // 通り数の初期化
        long count = 0;

        // 各要素に対して二分探索を実行
        for (int i = 0; i < N; i++)
        {
            long left = i + 1;
            long right = N;

            // 二分探索で条件を満たす範囲を特定
            while (left < right)
            {
                long mid = left + (right - left) / 2;

                if (candidateNumbers[mid] - candidateNumbers[i] <= K)
                {
                    left = mid + 1; // 条件を満たす場合、右側に範囲を絞る
                }
                else
                {
                    right = mid; // 条件を満たさない場合、左側に範囲を絞る
                }
            }

            // 条件を満たす範囲の個数を加算
            count += left - (i + 1);
        }

        // 結果を出力
        Console.WriteLine(count);
    }
}
