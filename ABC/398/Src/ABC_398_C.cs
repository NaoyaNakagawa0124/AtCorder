using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string S = Console.ReadLine();
        long N = int.Parse(S);

        string[] readLine = Console.ReadLine().Split();
        long[] A = new long[N];

        Dictionary<long, int> countMap = new Dictionary<long, int>(); // Key: A[i], Value: A[i]の出現回数
        Dictionary<long, int> firstIndexMap = new Dictionary<long, int>(); // Key: A[i], Value: A[i]のインデックス

        for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(readLine[i]);
            if(countMap.ContainsKey(A[i]))
            {
                countMap[A[i]]++;
                if(firstIndexMap.ContainsKey(A[i]))
                {
                    firstIndexMap.Remove(A[i]);
                }
            }
            else
            {
                countMap.Add(A[i], 1);
                firstIndexMap.Add(A[i], i + 1);
            }
        }
        
        long max = 0;

        long answer = 0;

        // foreach(var item in firstIndexMap)
        // {
        //     Console.WriteLine(item.Key + " " + item.Value);
        // }

        foreach (var item in firstIndexMap)
        {
            if(item.Key > max)
            {
                max = item.Key;
                answer = item.Value;
            }
        }

        if(firstIndexMap.Count == 0)
        {
            Console.WriteLine(-1);
            return;
        }
        else
        {
            Console.WriteLine(answer);
        }
        
    }
}

