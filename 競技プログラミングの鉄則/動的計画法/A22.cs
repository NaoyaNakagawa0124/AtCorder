// Author: Nakagawa Naoya
// Date: 2024/12/5
// Comment: こっちはもうだいぶ慣れてきたね。ただしっかり条件を見ること。これであれば到達可能条件を忘れていた。    
using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] stepA = new int[N];
        int[] stepB = new int[N];

        string[] input = Console.ReadLine().Split();
        for(int i = 0; i < N - 1; i++)
        {
            stepA[i] = int.Parse(input[i]);
        }

        input = Console.ReadLine().Split();
        for (int i = 0; i < N - 1; i++)
        {
            stepB[i] = int.Parse(input[i]);
        }

        // マス[i]までの最大得点を記録する配列を作成。加えて0で初期化。
        long[] maxScore = new long [N];
        maxScore[0] = 0;

        // 到達不能な場合もあるのでその場合は見ないようにいったん-1を入れておく
        for(int i = 1; i < N; i++)
        {
            maxScore[i] = -1;
        }


        // マス[i]までのどこかでマス[i]へ行く定義がなければおかしい。なので基本的には前から探索するだけでいいはず。
        for (int i = 0; i < N - 1; i++)
        {
            if(maxScore[i] != -1)
            {   
                // Console.WriteLine($"{i + 1}ループ目");
                if(maxScore[stepA[i] - 1] <  maxScore[i] + 100)
                {
                    // Console.WriteLine($"maxScore[{stepA[i]}]は{i + 1}マス目のstepAを使って{maxScore[i] + 100}に更新したよ");
                    maxScore[stepA[i] - 1] = maxScore[i] + 100;
                }
                if(maxScore[stepB[i] - 1] < maxScore[i] + 150)
                {
                    // Console.WriteLine($"maxScore[{stepB[i]}]は{i + 1}マス目のstepBを使って{maxScore[i] + 150}に更新したよ");
                    maxScore[stepB[i] - 1] = maxScore[i] + 150;
                }
            }
        }
        Console.WriteLine(maxScore[N - 1]);
        // for(int i =0; i < N; i++)
        // {
        //     Console.Write(maxScore[i]);
        //     Console.Write(" ");
        // }
    }
}
