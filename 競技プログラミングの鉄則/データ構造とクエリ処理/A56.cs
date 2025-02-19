using System;
using System.Text;

class Program
{
    static long MOD = 1000000007;  // MOD は大きな素数
    static long BASE = 31;         // 基数（一般的に 31, 37 などが使われる）

    static void Main()
    {
        // 入力
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int Q = int.Parse(input[1]);
        string S = Console.ReadLine();

        // ハッシュ前計算
        long[] hash = new long[N + 1];   // ハッシュ値の累積配列
        long[] power = new long[N + 1];  // BASE の累乗を保存 (オーバーフロー対策)

        power[0] = 1;
        for (int i = 1; i <= N; i++)
        {
            power[i] = (power[i - 1] * BASE) % MOD;  // MOD を取る！
        }

        for (int i = 1; i <= N; i++)
        {
            hash[i] = (hash[i - 1] * BASE + (S[i - 1] - 'a' + 1)) % MOD;
        }

        // クエリ処理
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < Q; i++)
        {
            string[] query = Console.ReadLine().Split();
            int a = int.Parse(query[0]) - 1;
            int b = int.Parse(query[1]);
            int c = int.Parse(query[2]) - 1;
            int d = int.Parse(query[3]);

            // 部分ハッシュを求める (MOD を適用してオーバーフローを防ぐ)
            long hash1 = (hash[b] - hash[a] * power[b - a] % MOD + MOD) % MOD;
            long hash2 = (hash[d] - hash[c] * power[d - c] % MOD + MOD) % MOD;

            if (hash1 == hash2)
                result.AppendLine("Yes");
            else
                result.AppendLine("No");
        }

        Console.Write(result.ToString()); // 高速出力
    }
}
