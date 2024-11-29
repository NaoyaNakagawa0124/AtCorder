using System;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());

        int[] stepOne = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] stepTwo = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 各部屋にたどり着くための最短日数の配列を用意
        int[] shortestPathDays = new int[N];

        // まずは0部屋目と1部屋目への最短経路だけ代入しておく
        shortestPathDays[0] = 0;
        shortestPathDays[1] = stepOne[0];

        for(int i = 2; i < N; i++)
        {
            if(shortestPathDays[i - 2] + stepTwo[i - 2] > shortestPathDays[i - 1] + stepOne[i - 1])
            {
                shortestPathDays[i] = shortestPathDays[i - 1] + stepOne[i - 1];
            }
            else
            {
                shortestPathDays[i] = shortestPathDays[i - 2] + stepTwo[i - 2];
            }
        }

        
        // 結果を出力
        Console.WriteLine(shortestPathDays[N - 1]);
    }
}
