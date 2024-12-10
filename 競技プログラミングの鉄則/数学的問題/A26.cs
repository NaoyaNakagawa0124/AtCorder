using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());
        int[] queries = new int[N];

        for (int i = 0; i < N; i++)
        {
            queries[i] = int.Parse(Console.ReadLine());
        }

        // クエリの最大値を取得
        int maxQuery = queries.Max();

        // エラトステネスの篩で素数を判定
        bool[] isPrime = SieveOfEratosthenes(maxQuery);

        // クエリに応じて結果を出力
        foreach (var num in queries)
        {
            if (isPrime[num])
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }

    // エラトステネスの篩
    static bool[] SieveOfEratosthenes(int max)
    {
        bool[] isPrime = new bool[max + 1];
        for (int i = 2; i <= max; i++)
        {
            isPrime[i] = true;
        }

        int sqrtMax = (int)Math.Sqrt(max);
        for (int i = 2; i <= sqrtMax; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= max; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        return isPrime;
    }
}
