// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         string[] readline = Console.ReadLine().Split();
//         int N = int.Parse(readline[0]);
//         int M = int.Parse(readline[1]);

//         int[] vertex = new int[N];
//         List<int, int>[] graph = new List<int, int>[N];

//         // グラフの初期化
//         for (int i = 0; i < N; i++)
//         {
//             graph.Add(new List<Tuple<int, int>>());
//         }

//         // 頂点の情報を読み込み
//         readline = Console.ReadLine().Split();
//         for (int i = 0; i < N; i++)
//         {
//             vertex[i] = int.Parse(readline[i]);
//         }

//         // 辺の情報を読み込み
//         for (int i = 0; i < M; i++)
//         {
//             readline = Console.ReadLine().Split();
//             int from = int.Parse(readline[0]);
//             int to = int.Parse(readline[1]);
//             int weight = int.Parse(readline[2]);

//             graph[from].Add(to, weight);
//         }


//     }

//     static int BFS(List<int, int>[] graph, int start, int goal, int vertices)
//     {
//         // 距離配列を用意 (未訪問は -1 とする)
//         int[] distances = new int[vertices + 1];
//         for (int i = 0; i <= vertices; i++)
//         {
//             distances[i] = -1;
//         }

//         // BFSの初期設定
//         Queue<int> queue = new Queue<int>();
//         queue.Enqueue(start);
//         distances[start] = 0;

//         // キューが空になるまで探索
//         while (queue.Count > 0)
//         {
//             int current = queue.Dequeue();

//             // 隣接ノードを探索
//             foreach (int neighbor in graph[current])
//             {
//                 if (distances[neighbor] == -1) // 未訪問のノード
//                 {
//                     distances[neighbor] = distances[current] + 1;
//                     queue.Enqueue(neighbor);

//                     // 終点に到達したら距離を返す
//                     if (neighbor == goal)
//                     {
//                         return distances[neighbor];
//                     }
//                 }
//             }
//         }
// }
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] line = Console.ReadLine().Split();
        int N = int.Parse(line[0]); // 頂点数
        int M = int.Parse(line[1]); // 辺の数

        // 頂点の重み A[i]
        long[] A = new long[N + 1];
        line = Console.ReadLine().Split();
        for (int i = 1; i <= N; i++)
        {
            A[i] = long.Parse(line[i - 1]);
        }

        // グラフの隣接リスト
        List<Tuple<int, long>>[] graph = new List<Tuple<int, long>>[N + 1];
        for (int i = 0; i <= N; i++)
        {
            graph[i] = new List<Tuple<int, long>>();
        }

        // 辺の入力
        for (int i = 0; i < M; i++)
        {
            line = Console.ReadLine().Split();
            int u = int.Parse(line[0]);
            int v = int.Parse(line[1]);
            long B = long.Parse(line[2]);
            graph[u].Add(Tuple.Create(v, B));
            graph[v].Add(Tuple.Create(u, B)); // 無向グラフなので双方向
        }

        // ダイクストラ法を実行
        long[] dist = new long[N + 1];
        Array.Fill(dist, long.MaxValue);
        dist[1] = A[1];

        PriorityQueue<(long cost, int node), long> pq = new PriorityQueue<(long, int), long>();
        pq.Enqueue((A[1], 1), A[1]);

        while (pq.Count > 0)
        {
            var (currentCost, u) = pq.Dequeue();

            // 最短経路でない場合はスキップ
            if (currentCost > dist[u]) continue;

            foreach (var (v, B) in graph[u])
            {
                long newCost = dist[u] + B + A[v];
                if (newCost < dist[v])
                {
                    dist[v] = newCost;
                    pq.Enqueue((newCost, v), newCost);
                }
            }
        }

        // 出力
        for (int i = 2; i <= N; i++)
        {
            Console.Write(dist[i] + " ");
        }
        Console.WriteLine();
    }
}
