using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        long X = long.Parse(readline[1]);
        long Y = long.Parse(readline[2]);
        // 甘さを格納する配列
        List<long> list_Sweet = new List<long>();

        // しょっぱさを格納する配列
        List<long> list_Sweetness = new List<long>();
        
        readline = Console.ReadLine().Split();
        for(int i = 0; i < N; i++)
        {
            list_Sweet.Add(long.Parse(readline[i]));
        }

        readline = Console.ReadLine().Split();
        for(int i = 0; i < N; i++)
        {
            list_Sweetness.Add(long.Parse(readline[i]));
        }

        list_Sweet.Sort((a, b) => b.CompareTo(a));
        list_Sweetness.Sort((a, b) => b.CompareTo(a));


        long sum_Sweet = 0;
        long sum_Sweetness = 0;
        int count = 0;

        while(sum_Sweet <= X && sum_Sweetness <= Y && count < N)
        {
            sum_Sweet += list_Sweet[count];
            sum_Sweetness += list_Sweetness[count];
            count++;
        }
        Console.WriteLine(count);
    }
}
