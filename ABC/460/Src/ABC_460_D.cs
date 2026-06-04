using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // 入力が大きい（H*W <= 10^6）ので StreamReader で高速読み込み
        var sr = new StreamReader(Console.OpenStandardInput());

        // 1行目: H W
        string[] hw = sr.ReadLine().Split();
        int H = int.Parse(hw[0]);
        int W = int.Parse(hw[1]);

        // 盤面を1次元配列で保持（メモリ節約）。index = i * W + j
        int N = H * W;
        bool[] isBlack = new bool[N];   // 初期色（true=#）
        // distB: 最も近い初期「黒」マスへのチェビシェフ距離。-1 = 到達不可（黒が無い）
        // distW: 最も近い初期「白」マスへのチェビシェフ距離。-1 = 到達不可（白が無い）
        int[] distB = new int[N];
        int[] distW = new int[N];
        // 多始点BFS用キュー（黒始点・白始点で使い回し）
        int[] queue = new int[N];

        // 盤面読み込み
        for (int i = 0; i < H; i++)
        {
            string row = sr.ReadLine();
            int baseIdx = i * W;
            for (int j = 0; j < W; j++)
            {
                isBlack[baseIdx + j] = (row[j] == '#');
            }
        }

        // 多始点BFS（8近傍）。seedBlack=true なら黒(#)を始点、false なら白(.)を始点。
        // 結果を dist に書き込む。dist は呼び出し側で -1 初期化済み想定。
        void Bfs(int[] dist, bool seedBlack)
        {
            int head = 0, tail = 0;
            for (int k = 0; k < N; k++)
            {
                if (isBlack[k] == seedBlack)
                {
                    dist[k] = 0;
                    queue[tail++] = k;
                }
                else
                {
                    dist[k] = -1;
                }
            }
            while (head < tail)
            {
                int cur = queue[head++];
                int ci = cur / W;
                int cj = cur % W;
                int nd = dist[cur] + 1;
                for (int di = -1; di <= 1; di++)
                {
                    int ni = ci + di;
                    if (ni < 0 || ni >= H) continue;
                    int rowBase = ni * W;
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        if (di == 0 && dj == 0) continue;
                        int nj = cj + dj;
                        if (nj < 0 || nj >= W) continue;
                        int nidx = rowBase + nj;
                        if (dist[nidx] == -1)
                        {
                            dist[nidx] = nd;
                            queue[tail++] = nidx;
                        }
                    }
                }
            }
        }

        Bfs(distB, true);   // 各マス → 最寄りの初期黒までの距離
        Bfs(distW, false);  // 各マス → 最寄りの初期白までの距離

        // t = 10^100（巨大な偶数）後の色。規則は初期色で非対称：
        //   白始まり: 最寄り初期黒への距離 distB が「偶数」なら黒（distB>=0 が前提）
        //   黒始まり: 最寄り初期白への距離 distW が「奇数」なら黒（distW>=0 が前提）
        // 全黒なら distW=-1 で全マス白、全白なら distB=-1 で全マス白、と自然に処理される。
        var sb = new StringBuilder(N + H);
        for (int i = 0; i < H; i++)
        {
            int baseIdx = i * W;
            for (int j = 0; j < W; j++)
            {
                int idx = baseIdx + j;
                bool black;
                if (isBlack[idx])
                {
                    int d = distW[idx];
                    black = (d >= 0) && ((d & 1) == 1);
                }
                else
                {
                    int d = distB[idx];
                    black = (d >= 0) && ((d & 1) == 0);
                }
                sb.Append(black ? '#' : '.');
            }
            sb.Append('\n');
        }

        Console.Out.Write(sb.ToString());
    }
}
