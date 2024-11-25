using System;
class Program
{
    static int Main()
    {
        // 文字数を読み取る
        int string_length = int.Parse(Console.ReadLine());

        if(string_length % 2 == 0)
        {
            Console.WriteLine("No");
            return 0;
        }
        // 任意の文字列
        char[] target_string = Console.ReadLine().ToCharArray();

        for(int i = 0; i < (string_length + 1)/2 - 1; i++)
        {
            if(target_string[i] != '1')
            {
                Console.WriteLine("No");
                return 0;
            }   
        }

        if(target_string[(string_length + 1)/2 - 1]!= '/')
        {
            Console.WriteLine("No");
            return 0;
        }   

        for(int i = (string_length + 1)/2; i < string_length; i++)
        {
            if(target_string[i]!= '2')
            {
                Console.WriteLine("No");
                return 0;
            }   
        }
        Console.WriteLine("Yes");
        return 0;
    }
}