using System;

class Program
{
    static void Main()
    {
        string[] nm = Console.ReadLine().Split();
        int N = int.Parse(nm[0]);
        int M = int.Parse(nm[1]);

        long[] A = Array.ConvertAll(Console.ReadLine().Split(), long.Parse); // シャリ
        long[] B = Array.ConvertAll(Console.ReadLine().Split(), long.Parse); // ネタ

        Array.Sort(A);
        Array.Sort(B);

        // 両方昇順。シャリを軽い順に見て、今の最小ネタが乗るならペア成立。
        // 乗らない（シャリが軽すぎる）なら、残りネタはもっと重いので
        // このシャリは誰も乗せられない → 捨てて次のシャリへ。
        int j = 0;       // 次に乗せたいネタのインデックス
        int count = 0;
        for (int i = 0; i < N && j < M; i++)
        {
            // ネタの重さ B[j] <= シャリの重さ A[i] の 2 倍
            if (B[j] <= 2 * A[i])
            {
                count++;
                j++;
            }
        }

        Console.WriteLine(count);
    }
}
