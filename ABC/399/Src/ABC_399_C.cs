using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力を受け取る
        string[] firstLine = Console.ReadLine().Split();
        int vertices = int.Parse(firstLine[0]); // 頂点数
        int edges = int.Parse(firstLine[1]);    // 辺の数

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
            graph[v].Add(u);
        }

        // 各頂点の訪問状態を管理
        bool[] visited = new bool[vertices + 1];
        int components = 0; // 連結成分の数

        // 各頂点を確認し、未訪問なら新しい連結成分としてスタックを用いてDFSを実行
        DFSUsingStack(graph, 1, visited);

        // 結果を出力
        Console.WriteLine(components);
    }

    static int DFSUsingStack(List<int>[] graph, int startNode, bool[] visited)
    {
        // 削除すべき枝の数
        int deletedEdges = 0;
        
        // スタックを初期化
        Stack<int> stack = new Stack<int>();
        stack.Push(startNode);

        // スタックの先頭から始め、各頂点に対してDFSを実行
        int currentNode = startNode;
        
        // スタックが空になるまで探索を続ける
        while (stack.Count > 0)
        {
            startNode = currentNode;
            currentNode = stack.Pop();

            // 既に訪問済みの場合はスキップ
            if (visited[currentNode]) 
            {
                deletedEdges++;
                continue;
            }

            // 現在のノードを訪問済みにする
            visited[currentNode] = true;

            // 隣接ノードをスタックに追加
            foreach (int neighbor in graph[currentNode])
            {
                if (!visited[neighbor])
                {
                    stack.Push(neighbor);
                }
            }
        }
    }
}
