using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] readline = Console.ReadLine().Split();

        int N = int.Parse(readline[0]);
        int K = int.Parse(readline[1]);

        string target = Console.ReadLine();

        int[] alphabet = new int[26];
        for(int i = 0; i < target.Length; i++)
        {
            alphabet[target[i] - 'a']++;
        }

        string front = "";
        string back = "";

        int count = 1;
        for(int i = 0; i < N; i++)
        {
            count *= (i + 1);
        }

        for(int i = 0; i < 26; i++)
        {
            for(int j = 0; j < alphabet[i]; j++)
            {
                count /= (j + 1);
            }
        }

        Console.WriteLine(count);
        return 0;
    }
}
