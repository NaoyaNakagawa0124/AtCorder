using System;
class Program
{
    static int Main()
    {
        // 部屋数を読み取る
        int string_length = int.Parse(Console.ReadLine());
        int counter = 1;
        int max = 1;
        int j = 0;
        bool flag = true;
        // 任意の文字列
        char[] target_string = Console.ReadLine().ToCharArray();
        for(int i = 0 ; i < string_length; i++)
        {
            counter = 1;
            j = 0;
            flag = true;
            if(target_string[i] == '/')
            {
                while(flag)
                {
                    j++;
                    if(i - j < 0 || i + j > string_length)
                    {
                        flag = false;
                    }
                    else if(target_string[i - j] != '1' || target_string[i + j] != '2')
                    {
                        flag = false;
                    }
                    else
                    {
                        counter += 2;
                    }
                }
                if(max < counter)
                {
                    max = counter;
                }
                if(max > string_length / 2 || max > (string_length - i) * 2)
                {
                    Console.WriteLine(max);
                    return 0;
                }
            }
            i += j;
        }
        Console.WriteLine(max);
        return 0;
    }
}