using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 入力の読み取り
        string[] readline = Console.ReadLine().Split();
        int Height = int.Parse(readline[0]);
        int Width = int.Parse(readline[1]);
        int Distance = int.Parse(readline[2]);
        int Max = 0;

        // グリッドの読み取り
        char[,] grid = new char[Height, Width];
        List<(int, int)> floorCells = new List<(int, int)>();

        for(int i = 0; i < Height; i++)
        {
            string line = Console.ReadLine();
            for(int j = 0; j < Width; j++)
            {
                grid[i, j] = line[j];
                if(grid[i, j] == '.')
                {
                    floorCells.Add((i, j));
                }
            }
        }

        // 床セルの組み合わせを全て試す
        for(int first = 0; first < floorCells.Count; first++)
        {
            for(int second = first + 1; second < floorCells.Count; second++)
            {
                // 加湿器を2つ設置
                var (i1, j1) = floorCells[first];
                var (i2, j2) = floorCells[second];

                // カバー範囲を計算
                bool[,] covered = new bool[Height, Width];

                // 最初の加湿器のカバー範囲をマーク
                BFS(i1, j1, Distance, grid, covered, Height, Width);

                // 2つ目の加湿器のカバー範囲をマーク
                BFS(i2, j2, Distance, grid, covered, Height, Width);

                // カバーされた床セルの数をカウント
                int count = 0;
                for(int i = 0; i < Height; i++)
                {
                    for(int j = 0; j < Width; j++)
                    {
                        if(covered[i, j] && grid[i, j] == '.')
                        {
                            count++;
                        }
                    }
                }

                // 最大値を更新
                if(count > Max)
                {
                    Max = count;
                    // デバッグ用に詳細を出力（必要に応じてコメントアウト）
                    // Console.WriteLine($"Humidifiers at ({i1}, {j1}) and ({i2}, {j2}) cover {count} cells.");
                }
            }
        }

        Console.Write(Max);
        return 0;
    }

    // BFSを用いてカバー範囲をマークする関数
    static void BFS(int startI, int startJ, int D, char[,] grid, bool[,] covered, int Height, int Width)
    {
        // キューに初期位置を追加
        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((startI, startJ, 0));

        // 訪問済み配列（ローカル）を使用
        bool[,] visited = new bool[Height, Width];
        visited[startI, startJ] = true;

        while(queue.Count > 0)
        {
            var (i, j, dist) = queue.Dequeue();

            // 現在のセルをカバー済みにする
            if(grid[i, j] == '.')
            {
                covered[i, j] = true;
            }

            // 距離がDに達したらこれ以上探索しない
            if(dist == D)
            {
                continue;
            }

            // 上
            if(i - 1 >= 0 && !visited[i - 1, j])
            {
                queue.Enqueue((i - 1, j, dist + 1));
                visited[i - 1, j] = true;
            }

            // 下
            if(i + 1 < Height && !visited[i + 1, j])
            {
                queue.Enqueue((i + 1, j, dist + 1));
                visited[i + 1, j] = true;
            }

            // 左
            if(j - 1 >= 0 && !visited[i, j - 1])
            {
                queue.Enqueue((i, j - 1, dist + 1));
                visited[i, j - 1] = true;
            }

            // 右
            if(j + 1 < Width && !visited[i, j + 1])
            {
                queue.Enqueue((i, j + 1, dist + 1));
                visited[i, j + 1] = true;
            }
        }
    }
}
