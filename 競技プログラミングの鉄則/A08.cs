// やっぱりこれも累積和を使う方が圧倒的に軽い
// これはChatGPTで出したものだけど前回の経験もあって、累積和を使えば軽くなると分かっていたのでそれを前提でプロンプトに投げた

using System;

class Program
{
    static int Main()
    {
        // 1行目で行数と列数を読み取る
        string[] readLine_split = Console.ReadLine().Split(" ");
        int Height = int.Parse(readLine_split[0]);
        int Width = int.Parse(readLine_split[1]);

        // 2次元配列を読み込む
        int[,] matrix_Main = new int[Height, Width];
        for (int i = 0; i < Height; i++)
        {
            readLine_split = Console.ReadLine().Split(" ");
            for (int j = 0; j < Width; j++)
            {
                matrix_Main[i, j] = int.Parse(readLine_split[j]);
            }
        }

        // 累積和テーブルを作成
        int[,] prefixSum = new int[Height + 1, Width + 1];
        for (int i = 1; i <= Height; i++)
        {
            for (int j = 1; j <= Width; j++)
            {
                prefixSum[i, j] = matrix_Main[i - 1, j - 1]
                                + prefixSum[i - 1, j]
                                + prefixSum[i, j - 1]
                                - prefixSum[i - 1, j - 1];
            }
        }

        // クエリ数を読み取る
        int numQuestion = int.Parse(Console.ReadLine());
        int[,] calArea = new int[numQuestion, 4];

        // クエリを読み取る
        for (int i = 0; i < numQuestion; i++)
        {
            readLine_split = Console.ReadLine().Split(" ");
            for (int j = 0; j < 4; j++)
            {
                calArea[i, j] = int.Parse(readLine_split[j]);
            }
        }

        // 各クエリに対して累積和を使って合計を計算
        for (int i = 0; i < numQuestion; i++)
        {
            int x1 = calArea[i, 0];
            int y1 = calArea[i, 1];
            int x2 = calArea[i, 2];
            int y2 = calArea[i, 3];

            int sum_Matrix = prefixSum[x2, y2]
                           - prefixSum[x1 - 1, y2]
                           - prefixSum[x2, y1 - 1]
                           + prefixSum[x1 - 1, y1 - 1];

            Console.WriteLine(sum_Matrix);
        }
        return 0;
    }
}


//     using System;
//     using System.Collections.Generic;

//     class Program
//     {
//         static int Main()
//         {
//             // 最も基本的な標準入力の読み込み
//             // まず1行目の読み取り
//             string readLine = Console.ReadLine();
//             string[] readLine_split = readLine.Split(" ");

//             // 何行何列かを格納(文字列)
//             string Height_string = readLine_split[0];
//             string Width_string = readLine_split[1];

//             // 何行何列かを格納(数値列)
//             int Height_int = int.Parse(Height_string);
//             int Width_int = int.Parse(Width_string);

//             // 2次元配列を格納
//             int[,] matrix_Main = new int[Height_int, Width_int];
//             for(int i = 0; i < Height_int; i++)
//             {
//                 readLine = Console.ReadLine();
//                 readLine_split = readLine.Split(" ");
//                 for(int j = 0; j < Width_int; j++)
//                 {
//                     matrix_Main[i, j] = int.Parse(readLine_split[j]);
//                 }
//             }

//             // 問題数の読み取り
//             readLine = Console.ReadLine();
//             int numQuestion = int.Parse(readLine);
//             int[,] calArea = new int[numQuestion, 4];

//             // 問題の読み取り
//             for(int i = 0; i < numQuestion; i++)
//             {
//                 readLine = Console.ReadLine();
//                 readLine_split = readLine.Split(" ");
//                 for(int j = 0; j < 4; j++)
//                 {
//                     calArea[i,j] = int.Parse(readLine_split[j]);
//                 }
//             }

//             // 合計の宣言
//             int sum_Matrix = 0;

//             // 実際に計算していく
//             for(int i = 0; i < numQuestion; i++)
//             {
//                 for(int j = calArea[i, 0] - 1; j < calArea[i, 2]; j++)
//                 {
//                     for(int k = calArea[i, 1] - 1; k < calArea[i, 3]; k++)
//                     {
//                         sum_Matrix = sum_Matrix + matrix_Main[j, k];
//                     }
//                 }
//                 Console.WriteLine(sum_Matrix);
//                 sum_Matrix = 0;
//             }
//             return 0;
//         }
// }