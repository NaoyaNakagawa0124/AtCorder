using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // 除去しないブロックの除去時刻の代わりとして用いる十分大きな値
    const long INF = (long)1e18;
    
    static void Main()
    {
        var tokens = Console.ReadLine().Split();
        int N = int.Parse(tokens[0]);
        int W = int.Parse(tokens[1]);
        
        int[] blockX = new int[N + 1];
        long[] blockY = new long[N + 1];

        List<(long Y, int id)>[] columns = new List<(long, int)>[W];
        for (int c = 0; c < W; c++)
        {
            columns[c] = new List<(long, int)>();
        }
        
        for (int i = 1; i <= N; i++)
        {
            var line = Console.ReadLine().Split();
            int X = int.Parse(line[0]);
            long Y = long.Parse(line[1]);
            blockX[i] = X;
            blockY[i] = Y;
            columns[X - 1].Add((Y, i));
        }
        
        long[] colMinY = new long[W];
        int[] colCount = new int[W];
        for (int c = 0; c < W; c++)
        {
            columns[c].Sort((a, b) => a.Y.CompareTo(b.Y));
            colCount[c] = columns[c].Count;
            if (colCount[c] > 0)
                colMinY[c] = columns[c][0].Y;
            else
                colMinY[c] = INF; 
        }
        
        bool full = true;
        for (int c = 0; c < W; c++)
        {
            if (colCount[c] == 0)
            {
                full = false;
                break;
            }
        }
        
        int K = full ? colCount.Min() : 0;
        long T_first = full ? colMinY.Max() : 0;
        
        long[] removalTime = new long[N + 1];
        for (int i = 1; i <= N; i++)
        {
            removalTime[i] = INF;
        }
        if (full)
        {
            for (int c = 0; c < W; c++)
            {
                for (int r = 0; r < columns[c].Count; r++)
                {
                    int id = columns[c][r].id;
                    long Y = columns[c][r].Y;
                    int rank = r + 1;
                    if (rank <= K)
                        removalTime[id] = Math.Max(Y, T_first + (rank - 1));
                    else
                        removalTime[id] = INF;
                }
            }
        }

        int Q = int.Parse(Console.ReadLine());
        var output = new System.Text.StringBuilder();
        for (int i = 0; i < Q; i++)
        {
            var query = Console.ReadLine().Split();
            long T = long.Parse(query[0]); // 質問時刻 T (整数)
            int A = int.Parse(query[1]);   // ブロック番号 A

            output.AppendLine(T < removalTime[A] ? "Yes" : "No");
        }
        
        Console.Write(output);
    }
}
