using System;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine());
        
        for (int t = 0; t < T; t++)
        {
            var line = Console.ReadLine().Split();
            int N = int.Parse(line[0]);
            long H = long.Parse(line[1]);
            
            long prevTime = 0;
            long lo = H, hi = H;  // 初期状態：高度Hのみ可能
            bool possible = true;
            
            for (int i = 0; i < N; i++)
            {
                var parts = Console.ReadLine().Split();
                long time = long.Parse(parts[0]);
                long l = long.Parse(parts[1]);
                long u = long.Parse(parts[2]);
                
                long dt = time - prevTime;
                
                // ステップ1: 到達可能範囲を計算
                long newHi = hi + dt;                    // 上限：前の上限からずっと上昇
                long newLo = Math.Max(0, lo - dt);       // 下限：0より下には行けない
                
                // ステップ2: 目標範囲との交差を取る
                lo = Math.Max(newLo, l);
                hi = Math.Min(newHi, u);
                
                // ステップ3: 交差が空かチェック
                if (lo > hi)
                {
                    possible = false;
                    // 残りの入力を読み飛ばす
                    for (int j = i + 1; j < N; j++)
                        Console.ReadLine();
                    break;
                }
                
                prevTime = time;
            }
            
            Console.WriteLine(possible ? "Yes" : "No");
        }
    }
}