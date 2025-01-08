using System;

class Program
{
    static int Main()
    {
        // 入力の読み取り
        string[] readline = Console.ReadLine().Split();
        int H = int.Parse(readline[0]);
        int W = int.Parse(readline[1]);
        int X = int.Parse(readline[2]);
        int Y = int.Parse(readline[3]);

        // 2次元配列の初期化
        char[,] S = new char[H + 1, W + 1];
        bool[,] visited = new bool[H + 1, W + 1];

        for (int i = 1; i <= H; i++)
        {
            string readline2 = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                S[i, j + 1] = readline2[j];
            }
        }

        int houseCount = 0;
        if (S[X, Y] == '@')
        {
            houseCount++;
            visited[X, Y] = true;
        }
        string moveDirection = Console.ReadLine();

        foreach (char direction in moveDirection)
        {
            if (direction == 'U' && X - 1 >= 1 && (S[X - 1, Y] == '@' || S[X - 1, Y] == '.'))
            {
                X--;
            }
            else if (direction == 'D' && X + 1 <= H && (S[X + 1, Y] == '@' || S[X + 1, Y] == '.'))
            {
                X++;
            }
            else if (direction == 'L' && Y - 1 >= 1 && (S[X, Y - 1] == '@' || S[X, Y - 1] == '.'))
            {
                Y--;
            }
            else if (direction == 'R' && Y + 1 <= W && (S[X, Y + 1] == '@' || S[X, Y + 1] == '.'))
            {
                Y++;
            }

            if (S[X, Y] == '@' && !visited[X, Y])
            {
                houseCount++;
                visited[X, Y] = true;
            }
        }

        Console.WriteLine($"{X} {Y} {houseCount}");
        return 0;
    }
}
