using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int A = int.Parse(readline[0]);
        int B = int.Parse(readline[1]);
        int C = int.Parse(readline[2]);

        if(A == B)
        {
            Console.Write("No");
            return;
        }
        if(B != C)
        {
            Console.Write("No");
            return;
        }
        Console.Write("Yes");
        return;
    }
}

