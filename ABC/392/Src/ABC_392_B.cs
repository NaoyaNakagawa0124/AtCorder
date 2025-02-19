using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int M = int.Parse(readline[1]);
        List<int> list = new List<int>();
        readline = Console.ReadLine().Split();
        int missCount = 0;
        List<int> missNum = new List<int>();
        for(int i = 0; i < M; i++)
        {
            list.Add(int.Parse(readline[i]));
        }
        for(int i = 1; i <= N; i++)
        {
            if(!list.Contains(i))
            {
                missCount++;
                missNum.Add(i);
            }
        }
        Console.WriteLine(missCount);
        foreach(int miss in missNum)
        {
            Console.Write(miss + " ");
        }
        return 0;
    }
}
