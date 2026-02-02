using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        List<int, int> list = new List<int, int>();
        for (int i = 0; i < N; i++)
        {
            list.Add(0, 0);
            foreach (var item in list)
            {
                item.Value = item.Value + 1;
            }
        }
    }
}

