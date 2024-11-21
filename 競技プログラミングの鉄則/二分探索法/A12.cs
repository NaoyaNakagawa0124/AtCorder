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

        // プリンターの間隔（A1, A2, ..., AN）を取得
        string inputLine = Console.ReadLine();
        string[] stringArray = inputLine.Split();

        long[] printers = new long[stringArray.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            printers[i] = long.Parse(stringArray[i]);
        }


        // 二分探索の範囲を設定
        long left = 1;
        long right = (long)1e18; // 最大探索範囲

        while (left < right)
        {
            long mid = left + (right - left) / 2;

            // mid秒以内に印刷されるチラシの枚数を計算
            long count = 0;
            foreach (var printer in printers)
            {
                count += mid / printer;
                if (count >= K) break; // K以上ならこれ以上計算する必要はない
            }

            if (count >= K)
            {
                right = mid; // 条件を満たす場合、範囲を左側に絞る
            }
            else
            {
                left = mid + 1; // 条件を満たさない場合、範囲を右側に絞る
            }
        }

        // 条件を満たす最小の時間を出力
        Console.WriteLine(left);
    }
}
