using System;
using System.Collections.Generic;
using System.Linq; 

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] T = Console.ReadLine().Split();
        SortedDictionary<long, long> Horse = new SortedDictionary<long, long>();

        for (int i = 0; i < N; i++)
        {
            Horse.Add(int.Parse(T[i]), i);
        }

        var valueList = Horse.Values.ToList();

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"{valueList[i] + 1} ");
        }
    }
}

