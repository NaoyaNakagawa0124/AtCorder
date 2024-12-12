using System;

class Program
{
    const long MOD = 1000000007;

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        // コンビネーションの計算 (MOD付き)
        long result = CombinationMod(n, k);

        // 結果の表示
        Console.WriteLine(result);
    }

    static long ModPow(long baseValue, long exp, long mod)
    {
        long result = 1;
        while (exp > 0)
        {
            if ((exp & 1) == 1) result = result * baseValue % mod;
            baseValue = baseValue * baseValue % mod;
            exp >>= 1;
        }
        return result;
    }

    static long ModInverse(long x, long mod)
    {
        return ModPow(x, mod - 2, mod); // フェルマーの小定理
    }

    static long CombinationMod(int n, int k)
    {
        if (k > n) return 0;

        long numerator = 1; // 分子
        for (int i = 0; i < k; i++)
        {
            numerator = numerator * (n - i) % MOD;
        }

        long denominator = 1; // 分母
        for (int i = 1; i <= k; i++)
        {
            denominator = denominator * i % MOD;
        }

        return numerator * ModInverse(denominator, MOD) % MOD;
    }
}
