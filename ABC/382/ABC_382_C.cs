using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字数を読み取る
        string[] readline = Console.ReadLine().Split();
        int BisyokuLength = int.Parse(readline[0]);
        int SushiLength = int.Parse(readline[1]); 

        string[] bisyokuArray_string = Console.ReadLine().Split();
        int[] bisyokuArray = new int [BisyokuLength];
        bisyokuArray[0] = int.Parse(bisyokuArray_string[0]);
        
        List<int> searchList1 = new List<int>();
        List<int> searchList2 = new List<int>();

        searchList1.Add(1);
        searchList2.Add(bisyokuArray[0]);
        
        for(int i = 1; i < BisyokuLength; i++)
        {
            bisyokuArray[i] = int.Parse(bisyokuArray_string[i]);
            
            if(bisyokuArray[i -1] <= bisyokuArray[i])
            {
                bisyokuArray[i] = bisyokuArray[i - 1];
            }
            else
            {
                searchList1.Add(i + 1);
                searchList2.Add(bisyokuArray[i]);   
            }
        }

        string[] sushiArray_string = Console.ReadLine().Split();
        int[] sushiArray = new int [SushiLength];
        for(int i = 0; i < SushiLength; i++)
        {
            sushiArray[i] = int.Parse(sushiArray_string[i]);
        }

        int counter = 0;

        for(int i = 0; i < SushiLength; i++)
        {
            counter = 0;
            for(int j = 0; j < searchList1.Count; j++)
            {
                if(searchList2[j] <= sushiArray[i])
                {
                    Console.WriteLine(searchList1[j]);
                    counter++;
                    break;
                }
            }
            if(counter == 0)
            {
                Console.WriteLine(-1);
            }
        }
        return 0;
    }
}