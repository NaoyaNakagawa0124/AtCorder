using System;
using System.Collections.Generic;

class Program
{
    static int H;
    static int W;
    static char[,] grid;
    static int ans = 0;
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        H = int.Parse(readline[0]);
        W = int.Parse(readline[1]);
        grid = new char[H, W];
        for (int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                grid[i, j] = line[j];
                // Console.Write(grid[i, j]);
            }
            // Console.WriteLine();
        }
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (grid[i, j] == '.')
                {
                    bool is_out = BFS(i, j);
                    if (!is_out) ans++;
                }
            }
        }
        Console.Write(ans);
    }

    static bool BFS(int position_y, int position_x)
    {
        bool is_connect = false;
        // まずは白かどうかの確認
        if (grid[position_y, position_x] != '.')
        {
            return false;
        }

        // 探索済みとする
        grid[position_y, position_x] = '#';

        // ここから検証開始 ここアウトであれば連結成分もすべてアウト
        if (position_y - 1 < 0 || position_y + 1 >= H || position_x - 1 < 0 || position_x + 1 >= W)
        {
            // ここから先はOut_BFSとして回していく
            if (position_y - 1 >= 0 && grid[position_y - 1, position_x] == '.')
            {
                Out_BFS(position_y - 1, position_x);
            }
            if (position_y + 1 < H && grid[position_y + 1, position_x] == '.')
            {
                Out_BFS(position_y + 1, position_x);
            }
            if (position_x - 1 >= 0 && grid[position_y, position_x - 1] == '.')
            {
                Out_BFS(position_y, position_x - 1);
            }
            if (position_x + 1 < W && grid[position_y, position_x + 1] == '.')
            {
                Out_BFS(position_y, position_x + 1);
            }
            return true;
        }
        else
        {
            is_connect = false;
            is_connect |= BFS(position_y - 1, position_x);
            is_connect |= BFS(position_y + 1, position_x);
            is_connect |= BFS(position_y, position_x - 1);
            is_connect |= BFS(position_y, position_x + 1);
            return is_connect;
        }
    }

    static void Out_BFS(int position_y, int position_x)
    {
        // 探索済みとする
        grid[position_y, position_x] = '#';
        // ここから先はOut_BFSとして回していく
        if (position_y - 1 >= 0 && grid[position_y - 1, position_x] == '.')
        {
            Out_BFS(position_y - 1, position_x);
        }
        if (position_y + 1 < H && grid[position_y + 1, position_x] == '.')
        {
            Out_BFS(position_y + 1, position_x);
        }
        if (position_x - 1 >= 0 && grid[position_y, position_x - 1] == '.')
        {
            Out_BFS(position_y, position_x - 1);
        }
        if (position_x + 1 < W && grid[position_y, position_x + 1] == '.')
        {
            Out_BFS(position_y, position_x + 1);
        }
    }
}

