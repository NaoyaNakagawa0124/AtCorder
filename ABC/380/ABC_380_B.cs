using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        char[] target_string = Console.ReadLine().ToCharArray();

        int i = 1;
        int lastLine = 0;

        while(i < target_string.Length)
        {
            if(target_string[i] == '|')
            {
                if(i == target_string.Length -1)
                {
                    Console.Write($"{i - lastLine - 1}");
                    lastLine = i;
                    
                }
                else
                {
                    Console.Write($"{i - lastLine - 1} ");
                    lastLine = i;
                }
            }
            i++;
        }
        
        return 0;
    }
}