using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int M = int.Parse(readline[1]);
        int ans = 0;
        int tmp = M;

        while(true)
        {
            tmp = N % tmp;
            ans++;
            if(tmp == 0)
            {
                break;
            }
        }
        Console.Write(ans);
    }
}

