using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int H = int.Parse(readline[0]);
        int W = int.Parse(readline[1]);
        int Q = int.Parse(readline[2]);

        int[,] array = new int[H + 1, W + 1];

        int bombCounter = 0;

        for(int i = 0; i < Q; i++)
        {
            int j = 1;
            readline = Console.ReadLine().Split();
            int y = int.Parse(readline[0]);
            int x = int.Parse(readline[1]);

            if(array[y, x] == 0)
            {
                array[y, x] = 1;
                bombCounter++;
            }
            else
            {
                bool isbomb = false;
                // まずは上方向
                while(isbomb == true || y - j > 0)
                {
                    if(array[y - j, x] == 0)
                    {
                        isbomb = true;
                        bombCounter++;
                        array[y - j, x] = 1;
                        break;
                    }
                    j++;
                }

                j = 1;
                isbomb = false;

                // 次に下方向
                while(isbomb == true || y + j <= H)
                {
                    if(array[y + j, x] == 0)
                    {
                        isbomb = true;
                        bombCounter++;
                        array[y + j, x] = 1;
                        break;
                    }
                    j++;
                }

                // 次に左方向
                j = 1;
                isbomb = false;
                while(isbomb == true || x - j > 0)
                {
                    if(array[y, x - j] == 0)
                    {
                        isbomb = true;
                        bombCounter++;
                        array[y, x - j] = 1;
                        break;
                    }
                    j++;
                }

                // 次に右方向
                j = 1;
                isbomb = false;
                while(isbomb == true || x + j <= W)
                {
                    if(array[y, x + j] == 0)
                    {
                        isbomb = true;
                        bombCounter++;
                        array[y, x + j] = 1;
                        break;
                    }
                    j++;
                }
            }
        }
        Console.WriteLine(H * W - bombCounter);
    }
}
