using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine().Trim());
        var K = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
        
        long sumK = K.Sum();
        long half = sumK / 2;
        long best = 0;

        // bit全探索
        // s は 0～(2^N-1) まで全部分集合を表す
        for (int s = 0; s < (1 << N); s++)
        {
            long curSum = 0;
            for (int i = 0; i < N; i++)
            {
                if (((s >> i) & 1) == 1)
                {
                    curSum += K[i];
                    // すでに half を超えたらこれ以上足しても無駄なので break
                    if (curSum > half) break;
                }
            }

            if (curSum <= half && curSum > best)
            {
                best = curSum;
            }
        }
        Console.WriteLine(sumK - best);
    }
}
