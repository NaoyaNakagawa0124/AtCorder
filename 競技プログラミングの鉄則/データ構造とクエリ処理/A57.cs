using System;
using System.Text;

class Program
{
    static int LOG = 30; // log2(10^9) ≈ 30
    static void Main()
    {
        // 入力
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int Q = int.Parse(input[1]);
        int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // ダブリングテーブル (next[k][i]: i番の穴から 2^k 日後の穴)
        int[,] next = new int[LOG, N + 1];

        // 初期値 (1日後の移動)
        for (int i = 1; i <= N; i++)
        {
            next[0, i] = A[i - 1]; // A[i] は 1-indexed なので調整
        }

        // ダブリングの前計算
        for (int k = 1; k < LOG; k++)
        {
            for (int i = 1; i <= N; i++)
            {
                next[k, i] = next[k - 1, next[k - 1, i]];
            }
        }

        // クエリ処理
        StringBuilder result = new StringBuilder();
        for (int q = 0; q < Q; q++)
        {
            string[] query = Console.ReadLine().Split();
            int x = int.Parse(query[0]);
            long y = long.Parse(query[1]); // Y が 10^9 なので long にする

            // ダブリングで y 日後の位置を求める
            for (int k = 0; y > 0; k++)
            {
                if ((y & 1) == 1) // y の k ビット目が 1 なら、その分進む
                {
                    x = next[k, x];
                }
                y >>= 1; // y を右シフト (2進数で見て次の桁へ)
            }

            result.AppendLine(x.ToString());
        }

        Console.Write(result.ToString()); // まとめて出力
    }
}
