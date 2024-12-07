using System;
class Program
{
    static int Main()
    {
        // 文字数を読み取る
        string[] readline = Console.ReadLine().Split();
        int Hight = int.Parse(readline[0]);
        int Width = int.Parse(readline[1]); 
        int Distance = int.Parse(readline[2]); 
        int Max = 0;

        // 任意の文字列
        char[,] target_string = new char[Hight, Width];
        bool[,] target_visited = new bool[Hight, Width];
        bool[,] target_visited_tmp = new bool[Hight, Width];
        for(int i = 0; i < Hight; i++)
        {
            char[] target = Console.ReadLine().ToCharArray();
            for(int j = 0; j < Width; j++)
            {
                target_string[i,j] = target[j];
            }
        }

        for(int i = 0; i < Hight; i++)
        {
            for(int j = 0; j < Width; j++)
            {
                if(target_string[i , j] != '#')
                {
                    int A = returnValue(Distance, target_string, i, j, Hight, Width, target_visited);
                    target_visited_tmp = target_visited;

                    for(int k = 0; k < Hight; k++)
                    {
                        for(int l = 0; l < Width; l++)
                        {
                            if(target_string[k , l] != '#')
                            {
                                int B = returnValue(Distance, target_string, k, l, Hight, Width, target_visited);
                                if(A + B > Max)
                                {
                                    Max = A + B;
                                }
                                target_visited = target_visited_tmp;
                            }
                        }
                    }
                }
            }
            target_visited = Init_Array(target_visited, Hight, Width);
        }
        Console.Write(Max);
        return 0;
    }

    static bool[,] Init_Array(bool[, ] visited, int H, int W)
    {
        for(int i = 0; i < H; i++)
        {
            for(int j = 0; j < W; j++)
            {
                visited[i, j] = false;
            }
        }
        return visited;
    }

    static int returnValue(int Area, char[,] target_string, int i, int j, int Hight, int Width, bool[,] visited)
    {
        // すでに訪問済みであれば終了
        if (visited[i, j]) return 0;

        // 再帰を抜ける条件
        if (Area == 0) 
        {
            if(target_string[i, j] == '.')
            {
                visited[i, j] = true;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // 現在の位置を訪問済みに設定
        visited[i, j] = true;

        // カウンターの初期値
        int counter = 1;

        // 上
        if (i - 1 >= 0 && target_string[i - 1, j] == '.')
        {
            counter += returnValue_noVisited(Area - 1, target_string, i - 1, j, Hight, Width, visited);
        }

        // 下
        if (i + 1 < Hight && target_string[i + 1, j] == '.')
        {
            counter += returnValue_noVisited(Area - 1, target_string, i + 1, j, Hight, Width, visited);
        }

        // 左
        if (j - 1 >= 0 && target_string[i, j - 1] == '.')
        {
            counter += returnValue_noVisited(Area - 1, target_string, i, j - 1, Hight, Width, visited);
        }

        // 右
        if (j + 1 < Width && target_string[i, j + 1] == '.')
        {
            counter += returnValue_noVisited(Area - 1, target_string, i, j + 1, Hight, Width, visited);
        }

        // 再帰終了時に訪問済みを解除（必要に応じて）
        //visited[i, j] = false;

        return counter;
    }

    static int returnValue_noVisited(int Area, char[,] target_string, int i, int j, int Hight, int Width, bool[,] visited)
    {
        // すでに訪問済みであれば終了
        if (visited[i, j]) return 0;

        // 再帰を抜ける条件
        if (Area == 0) 
        {
            if(target_string[i, j] == '.')
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // 現在の位置を訪問済みに設定
        visited[i, j] = true;

        // カウンターの初期値
        int counter = 1;

        // 上
        if (i - 1 >= 0 && target_string[i - 1, j] == '.')
        {
            counter += returnValue_noVisited(Area - 1, target_string, i - 1, j, Hight, Width, visited);
        }

        // 下
        if (i + 1 < Hight && target_string[i + 1, j] == '.')
        {
            counter += returnValue_noVisited(Area - 1, target_string, i + 1, j, Hight, Width, visited);
        }

        // 左
        if (j - 1 >= 0 && target_string[i, j - 1] == '.')
        {
            counter += returnValue_noVisited(Area - 1, target_string, i, j - 1, Hight, Width, visited);
        }

        // 右
        if (j + 1 < Width && target_string[i, j + 1] == '.')
        {
            counter += returnValue_noVisited(Area - 1, target_string, i, j + 1, Hight, Width, visited);
        }

        // 再帰終了時に訪問済みを解除（必要に応じて）
        visited[i, j] = false;

        return counter;
    }
}