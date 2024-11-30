using System;
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
        for(int i = 0; i < BisyokuLength; i++)
        {
            bisyokuArray = int.Parse(bisyokuArray_string[i]);
        }

        string[] sushiArray_string = Console.ReadLine().Split();
        int[] sushiArray = new int [SushiLength];
        for(int i = 0; i < BisyokuLength; i++)
        {
            sushiArray = int.Parse(bisyokuArray_string[i]);
        }

        while(eatDay != 0)
        {
            if(target_string[i] == '@')
            {
                target_string[i] = '.';
                eatDay--;
            }
            i--;
        }

        for(i = 0; i < stringLength; i++)
        {
            Console.Write(target_string[i]);
        }

        return 0;
    }
}