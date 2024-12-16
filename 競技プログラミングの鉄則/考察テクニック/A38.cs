using System;
using System.Linq;

class Program
{
    static int Main()
    {
        // 2つの整数を入力
        string[] readline = Console.ReadLine().Split();
        long D = long.Parse(readline[0]);
        long N = long.Parse(readline[1]);

        int[] maxWorkingHours = new int[366];

        int sumWorkingHours = 0;

        for(int i = 0; i < 366; i++)
        {
            maxWorkingHours[i] = 24;
        }

        for(int i = 0; i < N; i++)
        {
            readline = Console.ReadLine().Split();
            for(int j = int.Parse(readline[0]); j <= int.Parse(readline[1]); j++)
            {
                if(maxWorkingHours[j] > int.Parse(readline[2]))
                {
                    maxWorkingHours[j] = int.Parse(readline[2]);
                }
            }
        }
        for(int i = 1; i <= D; i++)
        {
            sumWorkingHours += maxWorkingHours[i];
        }
        Console.WriteLine(sumWorkingHours);
        return 0;
    }
}
