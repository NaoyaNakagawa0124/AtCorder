using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        int Q = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();

        for(int i = 0; i < 100; i++)
        {
            stack.Push(0);
        }

        for (int i = 0; i < Q; i++)
        {
            string[] readLine = Console.ReadLine().Split(" ");
            {
                if(int.Parse(readLine[0]) == 1)
                {
                    stack.Push(int.Parse(readLine[1])); // スタックに代入
                }
                else if(int.Parse(readLine[0]) == 2)
                {
                    Console.WriteLine(stack.Peek()); // ここで一番上の値を参照
                    stack.Pop();
                }
            }
        }
        return 0;
    }
}

