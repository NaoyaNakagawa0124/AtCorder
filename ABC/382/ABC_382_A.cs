using System;
class Program
{
    static int Main()
    {
        // 文字数を読み取る
        string[] readline = Console.ReadLine().Split();
        int stringLength = int.Parse(readline[0]);
        int eatDay = int.Parse(readline[1]); 

        char[] target_string = Console.ReadLine().ToCharArray();

        int cokkieCounter = 0;


        for(int i = 0; i < stringLength; i++)
        {
            if(target_string[i] == '@')
            {
                cokkieCounter++;
            }   
        }
        Console.WriteLine(stringLength - cokkieCounter + eatDay);
        return 0;
    }
}