using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int H = int.Parse(input[0]);
        int W = int.Parse(input[1]);

        string[] S = new string[H];
        for (int i = 0; i < H; i++)
        {
            S[i] = Console.ReadLine();
        }

        int ans = 0;

        for (int h1 = 0; h1 < H; h1++)
        {
            for (int h2 = h1; h2 < H; h2++)
            {
                for (int w1 = 0; w1 < W; w1++)
                {
                    for (int w2 = w1; w2 < W; w2++)
                    {
                        if (IsPointSymmetric(S, h1, h2, w1, w2))
                        {
                            ans++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(ans);
    }

    static bool IsPointSymmetric(string[] S, int h1, int h2, int w1, int w2)
    {
        for (int i = h1; i <= h2; i++)
        {
            for (int j = w1; j <= w2; j++)
            {
                int pi = h1 + h2 - i;
                int pj = w1 + w2 - j;
                if (S[i][j] != S[pi][pj])
                {
                    return false;
                }
            }
        }
        return true;
    }
}