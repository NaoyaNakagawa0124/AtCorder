using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int[] A = new int[7];
        for(int i=0; i<readline.Length; i++)
        {
            int tmp = int.Parse(readline[i]);
            A[tmp]++;
        }

        readline = Console.ReadLine().Split();
        int[] B = new int[7];
        for(int i=0; i<readline.Length; i++)
        {
            int tmp = int.Parse(readline[i]);
            B[tmp]++;
        }

        readline = Console.ReadLine().Split();
        int[] C = new int[7];
        for(int i=0; i<readline.Length; i++)
        {
            int tmp = int.Parse(readline[i]);
            C[tmp]++;
        }
        
        int probability_456 = A[4] * B[5] * C[6];
        int probability_465 = A[4] * B[6] * C[5];
        int probability_546 = A[5] * B[4] * C[6];
        int probability_564 = A[5] * B[6] * C[4];
        int probability_645 = A[6] * B[4] * C[5];
        int probability_654 = A[6] * B[5] * C[4];

        double total = probability_456 + probability_465 + probability_546 + probability_564 + probability_645 + probability_654;
        double ans = total/216;
        Console.Write(ans);
    }
}

