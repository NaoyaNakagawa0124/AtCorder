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
        int Sum = 0;

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

        // 床についてすべて調査
        for(int first = 0; first < floorCells.Count; first++)
        {
            var (i1, j1) = floorCells[first];

            // カバー範囲を計算
            bool[,] covered = new bool[Height, Width];
            
            // 最初の加湿器のカバー範囲をマーク
            Sum += exploreFloor(i1, j1, 0, Distance, grid, Height, Width, covered);
        }
        Console.Write(Sum);
        return 0;
    }
    // BFSを用いてカバー範囲をマークする関数
    static int exploreFloor(int x, int y, int tmpSteps, int Distance, char[,] grid, int Height, int Width, bool[,] covered)
    {
        int[] xdimension = { 1, 0, -1, 0 };
        int[] ydimension = { 0, 1, 0, -1 };
        covered[x, y] = true;

        int pattern = 0;
        
        // ステップ数が任意の回数に到達したら到達可能な場所として記録して終了
        if(tmpSteps == Distance)
        {
            pattern = 1;
            covered[x, y] = false;
            return pattern;
        }

        // 全方向の探索を行う
        for(int i = 0; i < 4; i++)
        {
            int newX = x + xdimension[i];
            int newY = y + ydimension[i];
            if(newX >= 0 && newX < Height && newY >= 0 && newY < Width) 
            {
                if(covered[newX, newY] == false && grid[newX, newY] == '.')
                {
                    pattern += exploreFloor(newX, newY, tmpSteps + 1, Distance, grid, Height, Width, covered);
                }
            }
        }
        covered[x, y] = false;
        return pattern;
    }
}
