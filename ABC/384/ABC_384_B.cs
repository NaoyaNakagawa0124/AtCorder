using System;
using System.Collections.Generic;
class Program
{
    static int Main()
    {
        // 入力の読み取り
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int R = int.Parse(readline[1]);

        for(int i = 0; i < N; i++)
        {
            readline = Console.ReadLine().Split();
            if(int.Parse(readline[0]) == 1)
            {
                if(R >= 1600 && R <= 2799)
                {
                    R = R + int.Parse(readline[1]);
                }
            }
            else
            {
                if(R>= 1200 && R <= 2399)
                {
                    R = R + int.Parse(readline[1]);
                }
            }
        }
        Console.Write(R);
        return 0;
    }
}
    