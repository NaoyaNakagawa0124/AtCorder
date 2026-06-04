using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string S = Console.ReadLine();
        char tmp = ' ';
        long count = 1;
        long total = 0;
        for(int i=0; i<S.Length; i++)
        {
            if(S[i] != tmp)
            {
                total += count;
                count++;
            }
            else
            {
                total++;
                count=1;
            }
            total = total % 998244353;
            tmp = S[i];
            Console.WriteLine(total);
        }
        Console.Write(total);
    }
}

