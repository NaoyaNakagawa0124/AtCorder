using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // クラスを用いてスタックの要素を表現
    class StackElement
    {
        public int Node;
        public int Parent;
        public bool Processed;

        public StackElement(int node, int parent, bool processed)
        {
            Node = node;
            Parent = parent;
            Processed = processed;
        }
    }

    static void Main()
    {
        // すべての入力を一度に読み取る
        string input = Console.In.ReadToEnd();
        string[] tokens = input.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        int index = 0;

        // N と K を読み取る
        int N = int.Parse(tokens[index++]);
        int K = int.Parse(tokens[index++]);

        // 隣接リストの初期化
        List<int>[] adj = new List<int>[N + 1];
        for (int i = 0; i <= N; i++)
        {
            adj[i] = new List<int>();
        }

        // N-1 本の辺を読み取って隣接リストを構築
        for (int i = 0; i < N - 1; i++)
        {
            int A = int.Parse(tokens[index++]);
            int B = int.Parse(tokens[index++]);
            adj[A].Add(B);
            adj[B].Add(A);
        }

        // 必要な頂点をセットとしてマーク
        bool[] required = new bool[N + 1];
        for (int i = 0; i < K; i++)
        {
            int V = int.Parse(tokens[index++]);
            required[V] = true;
        }

        // DFSのためのスタックと必要性を記録する配列
        Stack<StackElement> stack = new Stack<StackElement>();
        stack.Push(new StackElement(1, -1, false)); // ルートを1と仮定

        bool[] hasRequired = new bool[N + 1];
        int count = 0;

        while (stack.Count > 0)
        {
            StackElement current = stack.Pop();
            if (!current.Processed)
            {
                // 前処理: 子ノードをスタックに追加
                stack.Push(new StackElement(current.Node, current.Parent, true)); // 後処理用に再度プッシュ
                foreach (int neighbor in adj[current.Node])
                {
                    if (neighbor != current.Parent)
                    {
                        stack.Push(new StackElement(neighbor, current.Node, false));
                    }
                }
            }
            else
            {
                // 後処理: 必要性を判定
                bool currentHasRequired = required[current.Node];
                foreach (int neighbor in adj[current.Node])
                {
                    if (neighbor != current.Parent && hasRequired[neighbor])
                    {
                        currentHasRequired = true;
                    }
                }

                if (currentHasRequired)
                {
                    count++;
                    hasRequired[current.Node] = true;
                }
            }
        }

        // 結果を出力
        Console.Write(count);
    }
}
