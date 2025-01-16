    // 久しぶりの二分探索.....
    // 少し時間がかかってしまった.......
    
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
                        queue.Enqueue(readLine[1]);
                    }
                    else if(int.Parse(readLine[0]) == 2)
                    {
                        Console.WriteLine(queue.Peek());
                    }
                    else if(int.Parse(readLine[0]) == 3)
                    {
                        queue.Dequeue();
                    }
                }
            }
            return 0;
        }
}