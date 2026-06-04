using System;
using System.Collections.Generic;

class ConnectedComponentsDFS
{
    static bool[] Visited;
    static List<int>[] AdjacencyList;

    static int connectedVertex = 1;

    static void Main()
    {
        // 入力の読み込み
        string[] tokens = Console.ReadLine().Split();
        int N = int.Parse(tokens[0]); // 頂点数
        int M = int.Parse(tokens[1]); // 友達の数

        // アイテムの種類数で初期化
        Graph graph = new Graph(N);

        // M本の辺を読み込む
        for (int i = 0; i < M; i++)
        {
            tokens = Console.ReadLine().Split();
            int u = int.Parse(tokens[0]);
            int v = int.Parse(tokens[1]);
            graph.AddEdge(u, v);
        }

        // 隣接リストの取得
        AdjacencyList = graph.AdjacencyList;
        Visited = new bool[N + 1];
        int connectedComponents = 0;

        // アイテム1からの連結頂点の個数さえ調べればいい
        DFS(1);

        // 結果を出力
        Console.WriteLine(connectedVertex);
    }

    static void DFS(int node)
    {
        Visited[node] = true;

        foreach (var neighbor in AdjacencyList[node])
        {
            if (!Visited[neighbor])
            {
                connectedVertex++;
                DFS(neighbor);
            }
        }
    }
}

class Graph
{
    public int VertexCount { get; }
    public List<int>[] AdjacencyList { get; }

    public Graph(int vertexCount)
    {
        VertexCount = vertexCount;
        AdjacencyList = new List<int>[vertexCount + 1]; // 1-based indexing
        for (int i = 0; i <= vertexCount; i++)
        {
            AdjacencyList[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        AdjacencyList[u].Add(v);
    }
}
