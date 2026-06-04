using System;
using System.Text;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();
        for (int i = 0; i < T; i++)
        {
            string[] s = Console.ReadLine().Split();
            long x1 = long.Parse(s[0]);
            long y1 = long.Parse(s[1]);
            long r1 = long.Parse(s[2]);
            long x2 = long.Parse(s[3]);
            long y2 = long.Parse(s[4]);
            long r2 = long.Parse(s[5]);

            // 中心間距離の2乗（整数のまま、誤差ゼロ）
            long dx = x1 - x2;
            long dy = y1 - y2;
            long d2 = dx * dx + dy * dy;

            // 共有点を持つ条件: (R1 - R2)^2 <= d^2 <= (R1 + R2)^2
            long inner = (r1 - r2) * (r1 - r2);
            long outer = (r1 + r2) * (r1 + r2);

            sb.AppendLine(inner <= d2 && d2 <= outer ? "Yes" : "No");
        }
        Console.Write(sb);
    }
}
