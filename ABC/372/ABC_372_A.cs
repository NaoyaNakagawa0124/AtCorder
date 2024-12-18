using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string readline = Console.ReadLine();

        for(int i = 0; i < readline.Length; i++)
        {
            if(readline[i] != '.')
            {
                Console.Write(readline[i]);
            }
        }
        return 0;
    }
}