using System;

class Program
{
    static void Main()
    {
        // 2つの整数を入力
        string[] readline = Console.ReadLine().Split();
        int a = int.Parse(readline[0]);
        int b = int.Parse(readline[1]);

        // 最大公約数を計算
        int gcdResult = GCD(a, b);

        // 結果を出力
        Console.WriteLine(gcdResult);
    }

    static int GCD(int a, int b)
    {
        // ユークリッドの互除法
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
