using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int M = int.Parse(readline[1]);
        int K = int.Parse(readline[2]);

        List<int> Head = new List<int>();
        readline = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            Head.Add(int.Parse(readline[i]));
        }
        Head.Sort();

        List<int> Body = new List<int>();
        readline = Console.ReadLine().Split();
        for (int i = 0; i < M; i++)
        {
            Body.Add(int.Parse(readline[i]));
        }
        Body.Sort();

        int tmpIndex = 0;
        int robot = 0;
        // 小さい頭から並べたうえで、小さい体と比較していく。
        for (int i = 0; i < N; i++)
        {
            for (int j = tmpIndex; j < M; j++)
            {
                if (Head[i] <= Body[j])
                {
                    robot++;
                    tmpIndex = j + 1;
                    break;
                }
            }
            if (robot == K)
            {
                break;
            }
        }
        if (robot == K)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

