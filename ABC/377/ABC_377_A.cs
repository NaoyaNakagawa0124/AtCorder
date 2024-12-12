using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        char[] target_string = Console.ReadLine().ToCharArray();
        int counterA = 0;
        int counterB = 0;
        int counterC = 0;
        for(int i = 0; i < target_string.Length; i++)
        {
            if(target_string[i] == 'A')
            {
                counterA++;
                if(counterA > 1)
                {
                    Console.WriteLine("No");
                    return 0;
                }
            }
            else if(target_string[i] == 'B')
            {
                counterB++;
                if(counterB > 1)
                {
                    Console.WriteLine("No");
                    return 0;
                }
            }
            else if(target_string[i] == 'C')
            {
                counterC++;
                if(counterC > 1)
                {
                    Console.WriteLine("No");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("No");
                return 0;
            }
        }
        Console.WriteLine("Yes");
        return 0;
    }
}