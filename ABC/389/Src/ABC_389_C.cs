using System;

class Program
{
    static int Main()
    {
        // 入力: H, W
        string[] hw = Console.ReadLine().Split();
        int H = int.Parse(hw[0]);
        int W = int.Parse(hw[1]);

        char[,] S = new char[H, W];
        for (int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                S[i, j] = line[j];
            }
        }

        int minRow = H, maxRow = -1;
        int minCol = W, maxCol = -1;

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (S[i, j] == '#')
                {
                    if (i < minRow) minRow = i;
                    if (i > maxRow) maxRow = i;
                    if (j < minCol) minCol = j;
                    if (j > maxCol) maxCol = j;
                }
            }
        }

        for (int i = minRow; i <= maxRow; i++)
        {
            for (int j = minCol; j <= maxCol; j++)
            {
                if (S[i, j] == '.') 
                {
                    Console.WriteLine("No");
                    return 0;
                }
            }
        }
        Console.WriteLine("Yes");
        return 0;
    }
}
