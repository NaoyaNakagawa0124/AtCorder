using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        string[] readline = Console.ReadLine().Split();
        int[] A = new int[3];
        for(int i = 0; i < 3; i++)
        {
            A[i] = int.Parse(readline[i]);
        }
        if(A[0] * A[1] == A[2])
        {
            Console.WriteLine("Yes");
        }
        else if(A[1] * A[2] == A[0])
        {
            Console.WriteLine("Yes");
        }
        else if(A[2] * A[0] == A[1])
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
        return 0;
    }
}
