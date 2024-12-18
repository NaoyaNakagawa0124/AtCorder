using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        int counter = 0;
        for(int i = 0; i < 12; i++)
        {
            string readline = Console.ReadLine();
            if(readline.Length == i + 1)
            {
                counter++;
            }
        }
        Console.Write(counter);
        return 0;
    }
}