using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int[] card = new int[7];
        int[] number_times = new int[13];
        
        for (int i = 0; i < 7; i++)
        {
            card[i] = int.Parse(readline[i]) - 1;
            number_times[card[i]]++;
        }

        

        // 別解
        SortedList<int, int> sortedList = new SortedList<int, int>();
        for(int i = 0; i < 13; i++)
        {
            sortedList.Add(i + 1, 0);
        }
        for (int i = 0; i < 7; i++)
        {
            sortedList[card[i]]++;
        }

        // ここでValueの順番に並び替え


        if(sortedList[0].Value >= 3 && sortedList[1].Value >= 2)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.Writeline("No");
        }
    }
}

