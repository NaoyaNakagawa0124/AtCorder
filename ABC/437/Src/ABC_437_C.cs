using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine());

        var results = new List<long>();

        for (int _ = 0; _ < T; _++)
        {
            int N = int.Parse(Console.ReadLine());

            var reindeers = new List<(long w, long p)>();
            long sumP = 0;

            for (int i = 0; i < N; i++)
            {
                var tokens = Console.ReadLine().Split();
                long w = long.Parse(tokens[0]);
                long p = long.Parse(tokens[1]);

                reindeers.Add((w, p));
                sumP += p;
            }

            // (W + P) が小さい順にソート
            reindeers.Sort((a, b) => (a.w + a.p).CompareTo(b.w + b.p));

            long sumW = 0;
            long count = 0;

            foreach (var item in reindeers)
            {
                long w = item.w;
                long p = item.p;

                sumP -= p;
                sumW += w;

                if (sumP < sumW)
                {
                    break;
                }

                count++;
            }


            results.Add(count);
        }

        // 出力
        Console.WriteLine(string.Join("\n", results));
    }
}
