using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        char[] target_string = Console.ReadLine().ToCharArray();
        Console.Write($"{target_string[1]}{target_string[2]}{target_string[0]} {target_string[2]}{target_string[0]}{target_string[1]}");
        return 0;
    }
}