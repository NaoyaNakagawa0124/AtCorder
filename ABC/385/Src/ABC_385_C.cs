using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] H = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Dictionary<int, int>[] dp = new Dictionary<int, int>[N];
        for (int i = 0; i < N; i++)
        {
            dp[i] = new Dictionary<int, int>();
        }

        int maxCount = 1;

        for (int j = 0; j < N; j++)
        {
            for (int i = 0; i < j; i++)
            {
                int d = j - i;

                if (H[i] == H[j])
                {
                    if (!dp[i].ContainsKey(d))
                    {
                        dp[i][d] = 1;
                    }

                    if (!dp[j].ContainsKey(d))
                    {
                        dp[j][d] = dp[i][d] + 1;
                    }
                    else
                    {
                        dp[j][d] = Math.Max(dp[j][d], dp[i][d] + 1);
                    }

                    maxCount = Math.Max(maxCount, dp[j][d]);
                }
            }
        }

        Console.WriteLine(maxCount);
    }
}
