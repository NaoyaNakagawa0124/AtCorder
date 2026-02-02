using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var first = Console.ReadLine().Split();
        long N = long.Parse(first[0]); // 実際には使わない
        int M = int.Parse(first[1]);

        // 置かれたブロックの左上座標を保持
        var placed = new HashSet<(long r, long c)>();

        int answer = 0;

        for (int i = 0; i < M; i++)
        {
            var rc = Console.ReadLine().Split();
            long r = long.Parse(rc[0]);
            long c = long.Parse(rc[1]);

            bool canPlace = true;

            // 周囲 3×3 をチェック
            for (long dr = -1; dr <= 1 && canPlace; dr++)
            {
                for (long dc = -1; dc <= 1; dc++)
                {
                    if (placed.Contains((r + dr, c + dc)))
                    {
                        canPlace = false;
                        break;
                    }
                }
            }

            if (canPlace)
            {
                placed.Add((r, c));
                answer++;
            }
        }

        Console.WriteLine(answer);
    }
}
