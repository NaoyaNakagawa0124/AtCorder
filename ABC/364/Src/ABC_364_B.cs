using System;
using System.Collections.Generic;

class Program
{

    struct position
    {
        public int y;
        public int x;
    }
    static int Main()
    {
        string[] readline = Console.ReadLine().Split();
        int H = int.Parse(readline[0]);
        int W = int.Parse(readline[1]);
        

        readline = Console.ReadLine().Split();
        int position_y = int.Parse(readline[0]);
        int position_x = int.Parse(readline[1]);

        position pos = new position();
        pos.y = position_y - 1;
        pos.x = position_x - 1;

        char[,] board = new char[H, W];

        for(int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();
            for(int j = 0; j < W; j++)
            {
                board[i, j] = line[j];
            }
        }

        // 最初の盤面の表示
        // board[pos.y, pos.x] = 'x';
        // for(int i = 0; i < H; i++)
        // {
        //     for(int j = 0; j < W; j++)
        //     {
        //         Console.Write(board[i, j]);
        //     }
        //     Console.WriteLine();
        // }
        // Console.WriteLine();

        string command = Console.ReadLine();
        for(int i = 0; i < command.Length; i++)
        {
            char direction = command[i];
            // Console.WriteLine(direction);
            // board[pos.y, pos.x] = '.';
            pos = grid_walk(board, pos, direction, H , W);
            // Console.WriteLine(pos.y + " " + pos.x);
            // board[pos.y, pos.x] = 'x';
            // for(int j = 0; j < H; j++)
            // {
            //     for(int k = 0; k < W; k++)
            //     {
            //         Console.Write(board[j, k]);
            //     }
            //     Console.WriteLine();
            // }
            // Console.WriteLine();
        }
        Console.WriteLine(($"{pos.y + 1} {pos.x + 1}"));
        return 0;
    }

    static position grid_walk(char[,] board, position pos, char direction, int H, int W)
    {
        if(direction == 'U')
        {
            if(pos.y  >= 1)
            {
                if(board[pos.y - 1, pos.x] == '.')
                {
                    pos.y -= 1;
                }
            }
        }
        else if(direction == 'D')
        {
            if(pos.y < H - 1)
            {
                if(board[pos.y + 1, pos.x] == '.')
                {
                    pos.y += 1;
                }
            }
        }
        else if (direction == 'L')
        {
            if(pos.x >= 1)
            {
                if(board[pos.y, pos.x - 1] == '.')
                {
                    pos.x -= 1;
                }     
            }
        }
        else if (direction == 'R')
        {
            if(pos.x < W - 1)
            {
                if(board[pos.y, pos.x + 1] == '.')
                {
                    pos.x += 1;
                }
            }   
        }
        return pos;
    }
}
