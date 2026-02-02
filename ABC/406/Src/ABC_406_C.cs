using System;
using System.Numerics; 

class Program
{
    static void Main()
    {
        int n  = int.Parse(Console.ReadLine());
        int[] P = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 1. 連続上昇・下降の長さを前計算
        int[] inc  = new int[n];
        int[] dec  = new int[n];
        int[] incR = new int[n];

        inc[0] = dec[0] = 1;
        for (int i = 1; i < n; i++)
        {
            inc[i] = (P[i - 1] < P[i]) ? inc[i - 1] + 1 : 1;
            dec[i] = (P[i - 1] > P[i]) ? dec[i - 1] + 1 : 1;
        }
        incR[n - 1] = 1;
        for (int i = n - 2; i >= 0; i--)
            incR[i] = (P[i] < P[i + 1]) ? incR[i + 1] + 1 : 1;

        long ans = 0;

        // 2. “谷”を固定して数える
        for (int v = 1; v < n - 1; v++)
        {
            if (!(P[v - 1] > P[v] && P[v] < P[v + 1])) continue;  // 谷でない

            int decLen = dec[v];                    // 下降区間の長さ
            int p = v - decLen + 1;                 // ピーク候補

            if (p <= 0 || p >= v)       continue;
            if (!(P[p - 1] < P[p] && P[p] > P[p + 1])) continue; 

            int left  = inc[p]  - 1;   // 左端の選び方
            int right = incR[v] - 1;   // 右端の選び方
            if (left > 0 && right > 0)
                ans += (long)left * right;
        }

        Console.WriteLine(ans);
    }
}
