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

        int count = 0;

        // カードの枚数と目標の数の格納(文字列)
        string numCards_string = readLine_split[0];
        string targetNum_string = readLine_split[1];

        // カードの枚数と目標の数の格納(数値列)
        int numCards_int = int.Parse(numCards_string);
        int targetNum_int = int.Parse(targetNum_string);

        // 愚直に3重ループ
        for(int i = 1; i < numCards_int + 1; i++)
        {
            for(int j = 1; j < numCards_int + 1; j++)
            {
                if(targetNum_int - i - j > 0 && targetNum_int - i - j <= numCards_int)
                {
                    count++;
                }
            }
        }
        Console.Write(count);
        return 0;
    }
}

