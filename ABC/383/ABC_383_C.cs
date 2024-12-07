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

        // グリッドの読み取りと加湿器の位置の収集
        char[,] grid = new char[Height, Width];
        List<(int, int)> humidifiers = new List<(int, int)>();

        for(int i = 0; i < Height; i++)
        {
            string line = Console.ReadLine();
            for(int j = 0; j < Width; j++)
            {
                grid[i, j] = line[j];
                if(grid[i, j] == 'H')
                {
                    humidifiers.Add((i, j));
                    // 'H' を '.' に変更しても問題ない場合
                    grid[i, j] = '.';
                }
            }
        }

        // カバーされたセルを記録する配列
        bool[,] covered = new bool[Height, Width];
        // 各セルへの最短距離を記録する配列
        int[,] distance = new int[Height, Width];

        // 初期化
        for(int i = 0; i < Height; i++)
            for(int j = 0; j < Width; j++)
                distance[i, j] = -1; // 未到達

        // マルチソース BFS のためのキュー
        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();

        // 加湿器の位置をキューに追加し、距離を 0 に設定
        foreach(var (i, j) in humidifiers)
        {
            queue.Enqueue((i, j, 0));
            distance[i, j] = 0;
            covered[i, j] = true; // 加湿器自身は常にカバーされる
        }

        // BFS の探索
        int[] di = {-1, 1, 0, 0}; // 上下左右
        int[] dj = {0, 0, -1, 1};

        while(queue.Count > 0)
        {
            var (i, j, dist) = queue.Dequeue();

            if(dist >= Distance)
                continue;

            for(int dir = 0; dir < 4; dir++)
            {
                int ni = i + di[dir];
                int nj = j + dj[dir];

                if(ni >= 0 && ni < Height && nj >= 0 && nj < Width)
                {
                    if(grid[ni, nj] != '#' && distance[ni, nj] == -1)
                    {
                        distance[ni, nj] = dist + 1;
                        if(grid[ni, nj] == '.')
                        {
                            covered[ni, nj] = true;
                        }
                        queue.Enqueue((ni, nj, dist + 1));
                    }
                }
            }
        }

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

        Console.Write(count);
        return 0;
    }
}