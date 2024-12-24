using System;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());
        int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // カウント変数
        long count = 0;

        // 現在の部分列の長さを記録
        int currentLength = 1;

        // 右端を固定して探索
        for (int i = 1; i < N; i++)
        {
            // 等差数列の条件を確認
            if (i >= 2 && A[i] - A[i - 1] == A[i - 1] - A[i - 2])
            {
                // 等差数列が続く場合、長さを拡張
                currentLength++;
            }
            else
            {
                // 等差数列が途切れた場合、長さをリセット
                currentLength = 2;
            }

            // 部分列の数を追加
            count += currentLength - 1;
        }

        // 長さ1の部分列はすべて等差数列
        count += N;

        // 結果を出力
        Console.WriteLine(count);
    }
}
