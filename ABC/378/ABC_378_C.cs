using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] quotient = new int[N];
        int[] remainder = new int[1000000001];
        string[] readline = Console.ReadLine().Split();
        for(int i = 0; i < N; i++)
        {
            quotient[i] = int.Parse(readline[i]);
        }
        for(int i = 0; i < N; i++)
        {
            if(remainder[quotient[i]] == 0)
            {
                if(i != N - 1)
                {
                    Console.Write("-1");
                    Console.Write(" ");
                    remainder[quotient[i]] = i + 1;
                }
                else
                {
                    Console.Write("-1");
                }
            }
            else
            {
                if(i != N - 1)
                {
                    Console.Write(remainder[quotient[i]]);
                    Console.Write(" ");
                    remainder[quotient[i]] = i + 1;
                }
                else
                {
                    Console.Write(remainder[quotient[i]]);
                }
            }
        }
    }
}
