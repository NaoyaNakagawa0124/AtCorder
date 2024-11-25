using System;
class Program
{
    static int Main()
    {
        // 文字数を読み取る
        char[] target_string = Console.ReadLine().ToCharArray();
        int string_length = target_string.Length;

        if(string_length % 2 == 1)
        {
            Console.WriteLine("No");
            return 0;
        }

        for(int i = 0; i < (string_length + 1)/2; i++)
        {
            if(target_string[2 * i] != target_string[2 * i + 1])
            {
                Console.WriteLine("No");
                return 0;
            }
            for(int j = 0; j < string_length; j++)
            {
                if(target_string[2 * i] == target_string[j] && j != 2 * i && j != 2 * i + 1)
                {
                    Console.WriteLine("No");
                    return 0;
                }
            }
        }
        Console.WriteLine("Yes");
        return 0;
    }
}