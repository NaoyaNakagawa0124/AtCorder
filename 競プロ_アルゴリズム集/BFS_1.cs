// 入力:
// 6 7 // 頂点数 辺の数
// 1 2 // 辺の両端の頂点
// 1 3
// 2 4
// 2 5
// 3 5
// 4 6
// 5 6
// 1 6 // 始点と終点

// 出力:
// 3 // 最短経路の長さ


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力を受け取る
        string[] firstLine = Console.ReadLine().Split();
        int vertices = int.Parse(firstLine[0]);
        int edges = int.Parse(firstLine[1]);

        // グラフの隣接リストを作成
        List<int>[] graph = new List<int>[vertices + 1];
        for (int i = 0; i <= vertices; i++)
        {
            graph[i] = new List<int>();
        }

        // 辺の情報を入力
        for (int i = 0; i < edges; i++)
        {
            string[] edge = Console.ReadLine().Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);
            graph[u].Add(v);
            graph[v].Add(u); // 無向グラフ
        }

        // 始点と終点を入力
        string[] lastLine = Console.ReadLine().Split();
        int start = int.Parse(lastLine[0]);
        int goal = int.Parse(lastLine[1]);

        // BFSで最短経路を計算
        int shortestPathLength = BFS(graph, start, goal, vertices);

        // 結果を出力
        Console.WriteLine(shortestPathLength);
    }

    static int BFS(List<int>[] graph, int start, int goal, int vertices)
    {
        // 距離配列を用意 (未訪問は -1 とする)
        int[] distances = new int[vertices + 1];
        for (int i = 0; i <= vertices; i++)
        {
            distances[i] = -1;
        }

        // BFSの初期設定
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        distances[start] = 0;

        // キューが空になるまで探索
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            // 隣接ノードを探索
            foreach (int neighbor in graph[current])
            {
                if (distances[neighbor] == -1) // 未訪問のノード
                {
                    distances[neighbor] = distances[current] + 1;
                    queue.Enqueue(neighbor);

                    // 終点に到達したら距離を返す
                    if (neighbor == goal)
                    {
                        return distances[neighbor];
                    }
                }
            }
        }

        // 終点に到達できない場合
        return -1;
    }
}
