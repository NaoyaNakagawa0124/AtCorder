using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string S = Console.ReadLine();
        int N = int.Parse(Console.ReadLine());
        
        for(int i=0; i<S.Length; i++)
        {
            if(N <= i && i <= S.Length - N - 1)
            {
                Console.Write(S[i]);
            }
        }
    }
}

