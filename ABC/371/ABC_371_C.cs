using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var input = Console.In;

        int N = int.Parse(input.ReadLine().Trim());
        int MG = int.Parse(input.ReadLine().Trim());
        bool[,] G = new bool[N, N];
        for (int i = 0; i < MG; i++)
        {
            var line = input.ReadLine().Split();
            int u = int.Parse(line[0]) - 1;
            int v = int.Parse(line[1]) - 1;
            G[u, v] = true;
            G[v, u] = true;
        }

        int MH = int.Parse(input.ReadLine().Trim());
        bool[,] H = new bool[N, N];
        for (int i = 0; i < MH; i++)
        {
            var line = input.ReadLine().Split();
            int a = int.Parse(line[0]) - 1;
            int b = int.Parse(line[1]) - 1;
            H[a, b] = true;
            H[b, a] = true;
        }

        // A行列の読み込み
        long[,] A = new long[N, N];
        {
            // A_{1,2}, A_{1,3},..., A_{1,N}
            // A_{2,3},..., A_{N-1,N} を順に読み込み
            for (int i = 0; i < N - 1; i++)
            {
                var line = input.ReadLine().Split();
                for (int j = 0; j < line.Length; j++)
                {
                    // line[j]はA_{i+1, i+1+j+1}に対応(1-based)
                    // 0-basedではA[i, i+1+j]になる
                    A[i, i + 1 + j] = long.Parse(line[j]);
                    A[i + 1 + j, i] = A[i, i + 1 + j]; // 対称にしておく(参照しないなら不要だが一応)
                }
            }
        }

        // 頂点並び替えを全探索
        int[] perm = new int[N];
        for (int i = 0; i < N; i++) perm[i] = i;

        long ans = long.MaxValue;
        do
        {
            // perm[i]はGの頂点iに対してH側の頂点perm[i]を対応付け
            // G[i,j]とH[perm[i], perm[j]]を比較

            long cost = 0;
            // まず変換前に必要な辺トグル回数を算出
            // G[i,j]=true なら Hにも (perm[i], perm[j])が必要
            // G[i,j]=false なら Hにも (perm[i], perm[j])は不要
            // 一致しなければA[i,j]を加算
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    bool gEdge = G[i, j];
                    bool hEdge = H[perm[i], perm[j]];

                    if (gEdge != hEdge)
                    {
                        cost += A[i, j];
                        if (cost >= ans) goto skip; // 枝刈り
                    }
                }
            }

            if (cost < ans) ans = cost;

        skip:;
        } while (NextPermutation(perm));

        Console.WriteLine(ans);
    }

    // next_permutationを実装
    static bool NextPermutation(int[] array)
    {
        int n = array.Length;
        int k = n - 2;
        while (k >= 0 && array[k] >= array[k + 1]) k--;
        if (k < 0) return false;
        int l = n - 1;
        while (array[k] >= array[l]) l--;
        int temp = array[k]; array[k] = array[l]; array[l] = temp;
        Array.Reverse(array, k + 1, n - (k + 1));
        return true;
    }
}


// using System;
// class Program
// {
//     static int Main()
//     {
//         // 文字列の読み込み;
//         int N = int.Parse(Console.ReadLine());
//         int MG = int.Parse(Console.ReadLine());
        
//         bool[,] G = new bool[N + 1, N + 1];
//         int [] GedgeCounter = new int[N + 1];
//         for(int i = 0; i < MG; i++)
//         {
//             string[] readline = Console.ReadLine().Split();
//             int a = int.Parse(readline[0]);
//             int b = int.Parse(readline[1]);
//             G[a, b] = true;
//             GedgeCounter[a]++;
//             GedgeCounter[b]++;
//         }

//         bool[,] H = new bool[N + 1, N + 1];
//         int [] HedgeCounter = new int[N + 1];
//         int MH = int.Parse(Console.ReadLine());
//         for(int i = 0; i < MH; i++)
//         {
//             string[] readline = Console.ReadLine().Split();
//             int a = int.Parse(readline[0]);
//             int b = int.Parse(readline[1]);
//             H[a, b] = true;    
//             HedgeCounter[a]++;
//             HedgeCounter[b]++;
//         }

//         List<(int, int)> G_edges = new List<(int, int)> // 左は始点で右は始点からの枝の数
//         List<(int, int)> H_edges = new List<(int, int)>
//         G_edges.Sort((x, y) => x.Item2.CompareTo(y.Item2));
//         H_edges.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        
//         for(int i = 1; i < N + 1; i++)
//         {
//             G_edges.Add(i, GedgeCounter[i]);
//             H_edges.Add(i, HedgeCounter[i]);
//         }

        

//         int[,] cost = new int[N + 1, N + 1];
//         for(int i = 1; i < N - 1; i++)
//         {
//             string[] readline = Console.ReadLine().Split();
//             for(int j = i; j < N; j++)
//             {
//                 cost[i, j + 1] = int.Parse(readline[j - i]);
//             }
//         }
//         int lastEdge = int.Parse(Console.ReadLine());
//         cost[N - 1, N] = lastEdge;

//         int totalCost = 0;
//         for(int i = 1; i < N + 1; i++)
//         {
//             for(int j = i + 1; j < N + 1; j++)
//             {
//                 if(G[i, j] != H[i, j])
//                 {
//                     Console.WriteLine($"{i}{j}についてのコストを払ったよ");
//                     totalCost += cost[i, j];
//                 }
//             }
//         }
//         Console.WriteLine(totalCost);
//         return 0;
//     }
// }