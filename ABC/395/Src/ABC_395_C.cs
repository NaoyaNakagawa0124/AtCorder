using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine()); 
        string[] readline = Console.ReadLine().Split();
        int[] A = new int[N];
        for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(readline[i]);
        }
        
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
        for (int i = 0; i < N; i++)
        {
            if (dic.ContainsKey(A[i]))
            {
                dic[A[i]].Add(i);
            }
            else
            {
                dic.Add(A[i], new List<int>() { i });
            }
        }

        long minRange = 1000000000;
        bool duplicate = false;
        foreach (KeyValuePair<int, List<int>> pair in dic)
        {
            if (pair.Value.Count > 1)
            {
                duplicate = true;
                int range = 1000000000;
                for (int i = 1; i < pair.Value.Count; i++)
                {
                    range = Math.Min(range, pair.Value[i] - pair.Value[i - 1] + 1);
                }
                minRange = Math.Min(minRange, range);
            }
        }
        if(duplicate)
        {
            Console.WriteLine(minRange);
        }
        else
        {
            Console.WriteLine(-1);
        }
    }
}

