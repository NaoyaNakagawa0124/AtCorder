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

            // 日付数と質問数の格納(文字列)
            string numDays_string = readLine_split[0];
            string numQuestions_string = readLine_split[1];

            // 日付数と質問数の格納(数値列)
            int numDays_int = int.Parse(numDays_string);
            int numQuestions_int = int.Parse(numQuestions_string);

            // 各日付の来客数を格納
            readLine = Console.ReadLine();
            readLine_split = readLine.Split(" ");
            int[] dailyCustomers = new int[numDays_int + 1];

            //ここでN日目までの合計客数を保持しておく
            int[] totalVisitors = new int[numDays_int + 1];
            totalVisitors[0] = 0;

            for(int i = 0; i < numDays_int; i++)
            {
                dailyCustomers[i + 1] = int.Parse(readLine_split[i]);
                totalVisitors[i + 1] = totalVisitors[i] + dailyCustomers[i + 1];
            }

            // 各問題の計算開始日付と計算終了日付の格納
            int calculationStartDate = 0;
            int calculationEndDate = 0;

            for(int i = 0; i < numQuestions_int; i++)
            {
                readLine = Console.ReadLine();
                readLine_split = readLine.Split(" ");
                calculationStartDate = int.Parse(readLine_split[0]);
                calculationEndDate = int.Parse(readLine_split[1]);

                Console.WriteLine(totalVisitors[calculationEndDate] - totalVisitors[calculationStartDate -1]);
            }
            return 0;
        }
}

// これじゃタイムアウトしてしまった
//     using System;
//     using System.Collections.Generic;

//     class Program
//     {
//     static int Main()
//     {
//         // 最も基本的な標準入力の読み込み
//         // まず1行目の読み取り
//         string readLine = Console.ReadLine();
//         string[] readLine_split = readLine.Split(" ");

//         int count = 0;

//         // カードの枚数と目標の数の格納(文字列)
//         string numDays_string = readLine_split[0];
//         string numQuestions_string = readLine_split[1];

//         // カードの枚数と目標の数の格納(数値列)
//         int numDays_int = int.Parse(numDays_string);
//         int numQuestions_int = int.Parse(numQuestions_string);

//         // 各日付の来客数を格納
//         readLine = Console.ReadLine();
//         readLine_split = readLine.Split(" ");
//         int[] dailyCustomers = new int[numDays_int];

//         for(int i = 0; i < numDays_int; i++)
//         {
//             dailyCustomers[i] = int.Parse(readLine_split[i]);
//         }

//         // 各問題の計算開始日付と計算終了日付の格納
//         int calculationStartDate = 0;
//         int calculationEndDate = 0;

//         int totalVisitors = 0;

//         for(int i = 0; i < numQuestions_int; i++)
//         {
//             readLine = Console.ReadLine();
//             readLine_split = readLine.Split(" ");
//             calculationStartDate = int.Parse(readLine_split[0]);
//             calculationEndDate = int.Parse(readLine_split[1]);
//             for(int j = calculationStartDate - 1; j < calculationEndDate; j++)
//             {
//                 totalVisitors = totalVisitors + dailyCustomers[j];
//             }
//             Console.WriteLine(totalVisitors);
//             totalVisitors = 0;
//         }
//         return 0;
//     }
// }

