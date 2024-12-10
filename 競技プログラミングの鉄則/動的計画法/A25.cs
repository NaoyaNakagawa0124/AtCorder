// Author: Nakagawa Naoya
// Date: 2024/12/10
// Comment: BFS使って余裕でTLEになった。DPをどのように使えばいいかをしっかり考えるべきだった。
using System;

class Program
{
    static void Main()
    {
        // 入力の読み込み
        string[] hw = Console.ReadLine().Split();
        int Height = int.Parse(hw[0]);
        int Width = int.Parse(hw[1]);

        string[,] grid = new string[Height, Width];

        for (int i = 0; i < Height; i++)
        {
            char[] target_string = Console.ReadLine().ToCharArray();
            for (int j = 0; j < Width; j++)
            {
                grid[i, j] = target_string[j].ToString();
            }
        }

        // DP 配列を初期化
        long[,] dp = new long[Height, Width];
        dp[0, 0] = 1; // スタート地点は1通り

        // DP の遷移
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (grid[i, j] == "#") continue; // 壁の場合は通れない

                // 上から遷移
                if (i > 0 && grid[i - 1, j] == ".")
                {
                    dp[i, j] += dp[i - 1, j];
                }

                // 左から遷移
                if (j > 0 && grid[i, j - 1] == ".")
                {
                    dp[i, j] += dp[i, j - 1];
                }
            }
        }

        // 結果を出力（ゴールの経路数）
        Console.WriteLine(dp[Height - 1, Width - 1]);
    }
}


// using System;

// class Program
// {
//     static void Main()
//     {
//         // 入力の読み込み
//         string[] hw = Console.ReadLine().Split();

//         int Height = int.Parse(hw[0]);
//         int Width = int.Parse(hw[1]);

//         int pattern = 0;

//         string[, ] floor = new string[Height, Width];

//         for (int i = 0; i < Height; i++)
//         {
//             char[] target_string = Console.ReadLine().ToCharArray();
//             for(int j = 0; j < Width; j++)
//             {
//                 floor[i , j] = target_string[j].ToString();
//             }
//         }
//         pattern = BFS(0, 0, floor, Height, Width);
//         Console.WriteLine(pattern);
//     }

//     static int BFS(int startI, int startJ, string[,] grid, int Height, int Width)
//     {
//         // キューに初期位置を追加
//         Queue<(int, int)> queue = new Queue<(int, int)>();
//         queue.Enqueue((startI, startJ));

//         // 訪問済み配列（ローカル）を使用
//         bool[,] visited = new bool[Height, Width];
//         visited[startI, startJ] = true;

//         int counter = 0;

//         while(queue.Count > 0)
//         {
//             var (i, j) = queue.Dequeue();
//             // Console.WriteLine($"{i}, {j}をキューから出します");

//             // 右下に達したらこれ以上探索しない
//             if(i == Height - 1 && j == Width - 1)
//             {
//                 counter++;
//                 continue;
//             }

//             // 下
//             if(i + 1 < Height && grid[i + 1, j] == ".")
//             {
//                 // Console.WriteLine($"{i + 1}, {j}をキューに追加しました。");
//                 queue.Enqueue((i + 1, j));
//             }

//             // 右
//             if(j + 1 < Width && grid[i , j + 1] == ".")
//             {
//                 // Console.WriteLine($"{i}, {j + 1}をキューに追加しました。");
//                 queue.Enqueue((i, j + 1));
//             }
//         }

//         return counter;
//     }
// }
