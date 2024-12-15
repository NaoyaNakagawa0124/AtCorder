using System;
class Program
{
    static int Main()
    {
        // 文字数を読み取る
        int string_length = int.Parse(Console.ReadLine());

        int counter = 0;
        int max = 0;
        int j = 0;
        int k = 0;
        bool flag = true;
        bool isDuplicate = false;

        // 任意の文字列
        string[] target_string = Console.ReadLine().Split();
        for(int i = 0 ; i < string_length - 1; i++)
        {
            if(target_string[i] == target_string[i + 1])
            {
                counter += 2;
                j = i;
                while(flag)
                {
                    k = i;
                    j = j + 2;
                    if(j > string_length - 2)
                    {
                        flag = false;
                    }
                    else if(target_string[j] == target_string[j + 1])
                    {
                        while(k < j)
                        {
                            if(target_string[k] == target_string[j])
                            {
                                isDuplicate = true;
                                flag = false;
                            }
                            k += 2;
                        }
                        if(isDuplicate == false)
                        {
                            counter += 2;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
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

            if(counter != 0 && counter != 2)
            {
                i += counter - 1;
            }
            flag = true;
            isDuplicate = false;
            counter = 0;
            j = 0;
        }
        Console.WriteLine(max);
        return 0;
    }
}