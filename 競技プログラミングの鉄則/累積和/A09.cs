
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int Main()
        {
            // 最も基本的な標準入力の読み込み
            // まず1行目の読み取り
            string readLine = Console.ReadLine();
            string[] readLine_split = readLine.Split(" ");

            // 何行何列かを格納(文字列)
            string Height_string = readLine_split[0];
            string Width_string = readLine_split[1];
            string WinterDay_string = readLine_split[2];

            // 何行何列かを格納(数値列)
            int Height_int = int.Parse(Height_string);
            int Width_int = int.Parse(Width_string);
            int WinterDay_int = int.Parse(WinterDay_string);

            // 開始位置、終了位置の格納
            int startHeight = 0;
            int startWidth = 0;
            int endHeight = 0;
            int endWidth = 0;

            // 2次元配列を格納
            int[,] matrix_Main = new int[Height_int, Width_int];

            for(int i = 0; i < Height_int; i++)
            {
                for(int j = 0; j < Width_int; j++)
                {
                    matrix_Main[i, j] = 0;
                }
            }
            for(int i = 0; i < WinterDay_int; i++)
            {
                readLine = Console.ReadLine();
                readLine_split = readLine.Split(" ");
                startHeight = int.Parse(readLine_split[0]) - 1;
                startWidth = int.Parse(readLine_split[1]) - 1;
                endHeight = int.Parse(readLine_split[2]) - 1;
                endWidth = int.Parse(readLine_split[3]) - 1;

                matrix_Main[startHeight, startWidth] += 1;
                if(endWidth + 1 < Width_int)
                {
                    matrix_Main[startHeight, endWidth + 1] -= 1;
                }
                if(endHeight + 1 < Height_int)
                {
                    matrix_Main[endHeight + 1, startWidth] -= 1;
                }
                if(endHeight + 1 < Height_int && endWidth + 1 < Width_int)
                {
                    matrix_Main[endHeight + 1, endWidth + 1] += 1;
                }
            }

            // 横方向の累積和を求める
            for(int i = 0; i < Height_int; i++)
            {
                for(int j = 1; j < Width_int; j++)
                {
                    matrix_Main[i, j] += matrix_Main[i, j - 1];
                }
            }

            // 縦方向の累積和を求める
            for(int i = 0; i < Width_int; i++)
            {
                for(int j = 1; j < Height_int; j++)
                {
                    matrix_Main[j, i] += matrix_Main[j - 1, i];
                }
            }

            // 問題数の読み取り
           for(int i = 0; i < Height_int; i++)
            {
                for(int j = 0; j < Width_int; j++)
                {
                    if(j != Width_int - 1)
                    {
                        Console.Write($"{matrix_Main[i, j]} ");
                    }
                    else
                    {
                        Console.Write($"{matrix_Main[i, j]}");
                    }
                }
                Console.WriteLine();
            }
            return 0;
        }
}