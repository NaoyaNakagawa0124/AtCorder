using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] S = Console.ReadLine().Split();
        int N = int.Parse(S[0]);
        int M = int.Parse(S[1]);
        char[,] field = new char[N, N];
        for(int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            for(int j = 0; j < N; j++)
            {
                field[i, j] = line[j];
            }
        }

        char[,] target_field = new char[M, M];
        for(int i = 0; i < M; i++)
        {
            string line = Console.ReadLine();
            for(int j = 0; j < M; j++)
            {
                target_field[i, j] = line[j];
            }
        }
        bool is_match = false;

        for(int i = 0; i < N - M + 1; i++)
        {
            for(int j = 0; j < N - M + 1; j++)
            {
                if(field[i, j] == target_field[0, 0])
                {
                    is_match = true;
                    for(int k = 0; k < M; k++)
                    {
                        for(int l = 0; l < M; l++)
                        {
                            if(field[i + k, j + l] != target_field[k, l])
                            {
                                is_match = false;
                            }
                        }
                    }
                    if(is_match)
                    {
                        Console.WriteLine($"{i + 1} {j + 1}");
                        return 0;
                    }
                }
            }
        }
        return 0;
    }
}
