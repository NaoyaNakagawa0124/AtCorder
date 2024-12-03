// Author: Nakagawa Naoya
// Date: 2024/12/2 
// Comment: ナップザック問題来たあああああああああああ！！！！
// 自力で解けたぞおおおおおおおおおおおおおお！！！
using System;

class Program
{
    static void Main()
    {
        // 最初の入力を取得（NとK）
        string[] inputs = Console.ReadLine().Split();
        int numItem = int.Parse(inputs[0]);
        int maxCapacity = int.Parse(inputs[1]);

        int[] itemWeight = new int[numItem];
        long[] itemValue = new long[numItem]; 

        int maxValue = 0;

        for(int i = 0; i < numItem; i++)
        {
            inputs = Console.ReadLine().Split();
            itemWeight[i] = int.Parse(inputs[0]);
            itemValue[i] = long.Parse(inputs[1]); 
        }

        //まずはアイテムの個数×ナップザックの最大容量分の2次元配列を確保する。この2次元配列ではiアイテム目までの各ナップザックの最大値を更新していくもの
        long[,] stepValue = new long[numItem + 1, maxCapacity + 1]; 

        // 0個目(無のアイテム)の合計の価値は0なので1行目にはすべて0を代入
        for(int i = 0; i < maxCapacity + 1; i++)
        {
            stepValue[0, i] = 0;
        }

        // ナップザックの価値が0
        for(int i = 0; i < numItem + 1; i++)
        {
            stepValue[i , 0] = 0;
        }

        for(int i = 1; i < numItem + 1; i++)
        {
            for(int j = 1; j < maxCapacity + 1; j++)
            {
                // いったん今までの最大値を代入
                stepValue[i, j] = stepValue[i - 1, j];
                // 今までの要素に探索アイテムの価値を足して最大値を形成する場合。(!!!ただし前回(i - 1)の要素とずれている場合すでにi番目のアイテムを使用して何らかの操作が行われた後なので例外処理が必須!!!)
                if(j - itemWeight[i - 1] >= 0)
                {
                    //Console.WriteLine($"{j}回目");
                    if(stepValue[i , j] < stepValue[i - 1, j - itemWeight[i - 1]] + itemValue[i - 1])
                    {
                        // Console.WriteLine($"2: {i}ループ目: 重さ{j}の最大値を{stepValue[i - 1, j - itemWeight[i - 1]] + itemValue[i - 1]}に更新します");
                        stepValue[i, j] = stepValue[i - 1, j - itemWeight[i - 1]] + itemValue[i - 1];
                    }
                }
            }     
        }
        // デバッグ用
        // for(int i = 0; i < numItem + 1; i++)
        // {
        //     for(int j = 0; j < maxCapacity + 1; j++)
        //     {
        //         Console.Write(stepValue[i, j]);
        //         Console.Write(" ");
        //     }
        //     Console.WriteLine();
        // }
        Console.Write(stepValue[numItem, maxCapacity]);
    }
}
