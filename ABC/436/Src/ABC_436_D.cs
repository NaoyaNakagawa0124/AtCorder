// using System;
// using System.Collections.Generic;
// using System.Diagnostics;

// class ABC_436_C
// {
//     static int H = 0;
//     static int W = 0;

//     static int min_distance = int.MaxValue;

//     static void Main()
//     {

//         // 入力の読み込み
//         var tokens = Console.ReadLine().Split();


//         H = int.Parse(tokens[0]); // 高さ
//         W = int.Parse(tokens[1]); // 幅

//         // 探索対象のグラフの用意
//         char[,] graph = new char[H, W];

//         // 探索済みの配列
//         bool[,] visited = new bool[H, W];

//         // ワープポイントの配列
//         List<(int r, int c)>[] warpPoint = new List<(int r, int c)>[26];
//         for (int i = 0; i < 26; i++)
//         {
//             warpPoint[i] = new List<(int r, int c)>();
//         }

//         // 隣接リストは厳しそうなので迷路をそのまま扱う
//         for (int i = 0; i < H; i++)
//         {
//             string token = Console.ReadLine();
//             for (int j = 0; j < W; j++)
//             {
//                 graph[i, j] = token[j];
//                 if ('a' <= graph[i, j] && graph[i, j] <= 'z')
//                 {
//                     int index = alphabetToNumber(graph[i, j]);
//                     warpPoint[index].Add((i, j));
//                 }
//             }

//             BFS(graph, visited, warpPoint, 0, 0, H - 1, W - 1, 0);
//         }
//         if (min_distance == int.MaxValue)
//         {
//             Console.WriteLine(-1);
//         }
//         else
//         {
//             Console.WriteLine(min_distance);
//         }
//     }

//     static void BFS(char[,] graph, bool[,] visited, List<(int r, int c)>[] warpPoint, int tmpH, int tmpW, int targetH, int targetW, int tmpCost)
//     {

//         // 目的の場所かチェック
//         if (tmpH == targetH && tmpW == targetW)
//         {
//             min_distance = Math.Min(min_distance, tmpCost);
//             return;
//         }

//         // 探索済みでないかチェック
//         if (visited[tmpH, tmpW])
//         {
//             return;
//         }

//         // 動ける場所があるかどうかをチェック
//         visited[tmpH, tmpW] = true;
//         // まずは上方向
//         if (tmpH - 1 >= 0 && !visited[tmpH - 1, tmpW])
//         {
//             if (graph[tmpH - 1, tmpW] == '.')
//             {
//                 BFS(graph, visited, warpPoint, tmpH - 1, tmpW, targetH, targetW, tmpCost + 1);
//             }
//             if (graph[tmpH - 1, tmpW] == '#')
//             {
//                 // この場所には到達できない
//             }
//             if ('a' <= graph[tmpH - 1, tmpW] && graph[tmpH - 1, tmpW] <= 'z')
//             {
//                 // この場所には到達できる
//                 foreach (var item in warpPoint[alphabetToNumber(graph[tmpH - 1, tmpW])])
//                 {
//                     visited[item.r, item.c] = true;
//                     BFS(graph, visited, warpPoint, item.r, item.c, targetH, targetW, tmpCost + 2);
//                     visited[item.r, item.c] = false;
//                 }
//             }
//         }

//         // 左方向
//         if (tmpW - 1 >= 0 && !visited[tmpH, tmpW - 1])
//         {
//             if (graph[tmpH, tmpW - 1] == '.')
//             {
//                 BFS(graph, visited, warpPoint, tmpH, tmpW - 1, targetH, targetW, tmpCost + 1);
//             }
//             if (graph[tmpH, tmpW - 1] == '#')
//             {
//                 // この場所には到達できない
//             }
//             if ('a' <= graph[tmpH, tmpW - 1] && graph[tmpH, tmpW - 1] <= 'z')
//             {
//                 // この場所には到達できる
//                 foreach (var item in warpPoint[alphabetToNumber(graph[tmpH, tmpW - 1])])
//                 {
//                     BFS(graph, visited, warpPoint, item.r, item.c, targetH, targetW, tmpCost + 2);
//                 }
//             }
//         }

//         // 右方向
//         if (tmpW + 1 < W && !visited[tmpH, tmpW + 1])
//         {
//             if (graph[tmpH, tmpW + 1] == '.')
//             {
//                 BFS(graph, visited, warpPoint, tmpH, tmpW + 1, targetH, targetW, tmpCost + 1);
//             }
//             if (graph[tmpH, tmpW + 1] == '#')
//             {
//                 // この場所には到達できない
//             }
//             if ('a' <= graph[tmpH, tmpW + 1] && graph[tmpH, tmpW + 1] <= 'z')
//             {
//                 // この場所には到達できる
//                 foreach (var item in warpPoint[alphabetToNumber(graph[tmpH, tmpW + 1])])
//                 {
//                     visited[item.r, item.c] = true;
//                     BFS(graph, visited, warpPoint, item.r, item.c, targetH, targetW, tmpCost + 2);
//                 }
//             }
//         }

//         // 下方向
//         if (tmpH + 1 < H && !visited[tmpH + 1, tmpW])
//         {
//             if (graph[tmpH + 1, tmpW] == '.')
//             {
//                 BFS(graph, visited, warpPoint, tmpH + 1, tmpW, targetH, targetW, tmpCost + 1);
//             }
//             if (graph[tmpH + 1, tmpW] == '#')
//             {
//                 // この場所には到達できない
//             }
//             if ('a' <= graph[tmpH + 1, tmpW] && graph[tmpH + 1, tmpW] <= 'z')
//             {
//                 // この場所には到達できる
//                 foreach (var item in warpPoint[alphabetToNumber(graph[tmpH + 1, tmpW])])
//                 {
//                     visited[item.r, item.c] = true;
//                     BFS(graph, visited, warpPoint, item.r, item.c, targetH, targetW, tmpCost + 2);
//                 }
//             }
//         }
//     }

//     public static int alphabetToNumber(char column)
//     {
//         return column - 'a';
//     }
// }

using System;
using System.Collections.Generic;

class Program
{
    static int H, W;
    static char[,] grid;
    static int[,] dist;

    static void Main()
    {
        var hw = Console.ReadLine().Split();
        H = int.Parse(hw[0]);
        W = int.Parse(hw[1]);

        grid = new char[H, W];
        dist = new int[H, W];

        // ワープポイント
        List<(int r, int c)>[] warp = new List<(int r, int c)>[26];
        for (int i = 0; i < 26; i++)
            warp[i] = new List<(int r, int c)>();

        for (int i = 0; i < H; i++)
        {
            string s = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                grid[i, j] = s[j];
                dist[i, j] = int.MaxValue;

                if ('a' <= grid[i, j] && grid[i, j] <= 'z')
                {
                    warp[grid[i, j] - 'a'].Add((i, j));
                }
            }
        }

        // BFS
        Queue<(int r, int c)> q = new Queue<(int r, int c)>();
        q.Enqueue((0, 0));
        dist[0, 0] = 0;

        bool[] usedWarp = new bool[26];

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        while (q.Count > 0)
        {
            var (r, c) = q.Dequeue();
            int d = dist[r, c];

            // 上下左右
            for (int k = 0; k < 4; k++)
            {
                int nr = r + dr[k];
                int nc = c + dc[k];

                if (nr < 0 || nr >= H || nc < 0 || nc >= W) continue;
                if (grid[nr, nc] == '#') continue;
                if (dist[nr, nc] <= d + 1) continue;

                dist[nr, nc] = d + 1;
                q.Enqueue((nr, nc));
            }

            // ワープ
            if ('a' <= grid[r, c] && grid[r, c] <= 'z')
            {
                int idx = grid[r, c] - 'a';
                if (!usedWarp[idx])
                {
                    usedWarp[idx] = true;
                    foreach (var (wr, wc) in warp[idx])
                    {
                        if (dist[wr, wc] > d + 1)
                        {
                            dist[wr, wc] = d + 1;
                            q.Enqueue((wr, wc));
                        }
                    }
                }
            }
        }

        int ans = dist[H - 1, W - 1];
        Console.WriteLine(ans == int.MaxValue ? -1 : ans);
    }
}
