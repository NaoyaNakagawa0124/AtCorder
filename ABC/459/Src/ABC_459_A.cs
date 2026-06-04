using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string S = "HelloWorld";

        for(int i=0; i<S.Length; i++)
        {
            if(i+1 != N)
            {
                Console.Write(S[i]);
            }
        }
    
    }
}

