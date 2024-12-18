using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        char[,] floor_condition = new char[N, N];
        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < N; j++)
            {
                floor_condition[i, j] = line[j];
            }
        }

        int layers = N / 2; 
        for (int layer = 0; layer < layers; layer++)
        {
            int start = layer;
            int end = N - layer - 1;

            // この層の要素を取り出す (順序: 上辺→右辺→下辺→左辺)
            var temp = new System.Collections.Generic.List<char>();

            // 上辺 (left to right)
            for (int j = start; j <= end; j++) temp.Add(floor_condition[start, j]);
            // 右辺 (top+1 to bottom-1)
            for (int i = start+1; i <= end-1; i++) temp.Add(floor_condition[i, end]);
            // 下辺 (right to left)
            for (int j = end; j >= start; j--) temp.Add(floor_condition[end, j]);
            // 左辺 (bottom-1 to top+1)
            for (int i = end-1; i >= start+1; i--) temp.Add(floor_condition[i, start]);

            int perimeter = temp.Count; // この層の周囲の要素数
            int shift = perimeter / 4;  // 90度回転で要素をシフトさせる数

            var rotatedRing = new char[perimeter];
            for (int k = 0; k < perimeter; k++)
            {
                rotatedRing[(k + shift) % perimeter] = temp[k];
            }

            // 回転後の要素を再配置
            int idx = 0;
            // 上辺
            for (int j = start; j <= end; j++) floor_condition[start, j] = rotatedRing[idx++];
            // 右辺
            for (int i = start+1; i <= end-1; i++) floor_condition[i, end] = rotatedRing[idx++];
            // 下辺
            for (int j = end; j >= start; j--) floor_condition[end, j] = rotatedRing[idx++];
            // 左辺
            for (int i = end-1; i >= start+1; i--) floor_condition[i, start] = rotatedRing[idx++];
        }

        // 出力
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(floor_condition[i, j]);
            }
            Console.WriteLine();
        }
    }
}



// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         // 入力を受け取る
//         string readLine = Console.ReadLine();
//         long N = long.Parse(readLine); // N

//         char[, ] floor_condition = new char[N ,N];
//         for(int i = 0; i < N; i++)
//         {
//             string readline = Console.ReadLine();
//             for(int j = 0; j < N; j++)
//             {
//                 floor_condition[i , j] = readline[j];
//             }
//         }

//         // グリッドの変換を行う
//         for (int i = 1; i <= N / 2; i++) // iは1からN/2まで回す
//         {
//             // 一時的な配列を用意する
//             char[,] floor_condition2 = (char[,])floor_condition.Clone(); // floor_conditionを複製

//             for (int x = i; x <= N + 1 - i; x++) // xは条件に従って回す
//             {
//                 for (int y = i; y <= N + 1 - i; y++) // yも条件に従って回す
//                 {
//                     // マス (y, N + 1 - x) の色を置き換え
//                     floor_condition2[y - 1, N - x] = floor_condition[x - 1, y - 1];
//                 }
//             }

//             // 置き換えた結果を元の配列に反映
//             floor_condition = floor_condition2;
//         }


//         for(int i = 0; i < N; i++)
//         {
//             for(int j = 0; j < N; j++)
//             {
//                 Console.Write(floor_condition[i, j]);
//             }
//             if(i != N - 1)
//             {
//                 Console.WriteLine();
//             }
//         }
//     }
// }