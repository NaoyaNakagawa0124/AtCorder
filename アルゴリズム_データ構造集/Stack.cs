    // スタックの基本的な使用例
    //　スタックは先入れ後出しのデータ構造　本を積んでいくイメージ
    
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int Main()
        {
            int Q = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < Q; i++)
            {
                string[] readLine = Console.ReadLine().Split(" ");
                {
                    if(int.Parse(readLine[0]) == 1)
                    {
                        stack.Push(readLine[1]); // スタックに代入
                    }
                    else if(int.Parse(readLine[0]) == 2)
                    {
                        Console.WriteLine(stack.Peek()); // ここで一番上の値を参照
                    }
                    else if(int.Parse(readLine[0]) == 3)
                    {
                        stack.Pop(); // スタックから一番上の値を取り出す
                    }
                }
            }
            return 0;
        }
}