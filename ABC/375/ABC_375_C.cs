
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 入力を受け取る
        string readLine = Console.ReadLine();
        long N = long.Parse(readLine); // N

        char[, ] floor_condition = new char[N ,N];
        for(int i = 0; i < N; i++)
        {
            string readline = Console.ReadLine();
            for(int j = 0; j < N; j++)
            {
                floor_condition[i , j] = readline[j];
            }
        }

        // グリッドの変換を行う
        for (int i = 1; i <= N / 2; i++) // iは1からN/2まで回す
        {
            // 一時的な配列を用意する
            char[,] floor_condition2 = (char[,])floor_condition.Clone(); // floor_conditionを複製

            for (int x = i; x <= N + 1 - i; x++) // xは条件に従って回す
            {
                for (int y = i; y <= N + 1 - i; y++) // yも条件に従って回す
                {
                    // マス (y, N + 1 - x) の色を置き換え
                    floor_condition2[y - 1, N - x] = floor_condition[x - 1, y - 1];
                }
            }

            // 置き換えた結果を元の配列に反映
            floor_condition = floor_condition2;
        }


        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                Console.Write(floor_condition[i, j]);
            }
            if(i != N - 1)
            {
                Console.WriteLine();
            }
        }
    }
}