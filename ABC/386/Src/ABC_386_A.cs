using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] readline = Console.ReadLine().Split();

        int[] numTimes = new int[14];

        int twoPair = 0;
        int threePair = 0;

        for(int i = 0; i < readline.Length; i++)
        {
            numTimes[int.Parse(readline[i])]++;
        }

        for(int i = 0; i < numTimes.Length; i++)
        {
            if(numTimes[i] == 2)
            {
                twoPair++;
            }
            else if(numTimes[i] == 3)
            {
                threePair++;
            }
        }

        if(twoPair == 2 || threePair == 1)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }

        return 0;
    }
}
