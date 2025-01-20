    // キューの基本的な使用例
    // キューは先入れ先出しのデータ構造 列に後ろから並んでいくイメージ
    
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int Main()
        {
            int Q = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < Q; i++)
            {
                string[] readLine = Console.ReadLine().Split(" ");
                {
                    if(int.Parse(readLine[0]) == 1)
                    {
                        queue.Enqueue(readLine[1]); // キューに代入
                    }
                    else if(int.Parse(readLine[0]) == 2)
                    {
                        Console.WriteLine(queue.Peek()); // ここで先頭の値を参照
                    }
                    else if(int.Parse(readLine[0]) == 3)
                    {
                        queue.Dequeue(); // キューから一番上の値を取り出す
                    }
                }
            }
            return 0;
        }
}