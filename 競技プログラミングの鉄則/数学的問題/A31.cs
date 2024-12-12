using System;

class Program
{
    static void Main()
    {
        long N = long.Parse(Console.ReadLine());
        // 結果の表示
        Console.WriteLine(N / 3 +  N / 5 - N / 15);
    }
}
