using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 最も基本的な標準入力の読み込み
        // ここで目標の数の格納
        string readLine = Console.ReadLine();
        string[] readLine_split = readLine.Split(" ");
        string targetNum = readLine_split[1];

        // ここで候補となる数字列を格納
        readLine = Console.ReadLine();
        string[] numCandidates = readLine.Split(" ");

        // 判定
        for(int i = 0; i < numCandidates.Length; i++)
        {
            if(targetNum == numCandidates[i])
            {
                Console.WriteLine("Yes");
                return 0;
            }
        }
        Console.WriteLine("No");
        return 0;
    }
}
