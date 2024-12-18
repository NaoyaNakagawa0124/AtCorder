using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        string[] K = Console.ReadLine().Split();
        int[] A = new int[N];

        for(int i = 0; i < N; i++)
        {
            A[i] = int.Parse(K[i]);
        }

        K = Console.ReadLine().Split();
        int[] B = new int[N];
        for(int i = 0; i < N; i++)
        {
            B[i] = int.Parse(K[i]);
        }
        
        int Amax = A.Max();
        int Bmax = B.Max();

        long sumK = Amax + Bmax;

        Console.WriteLine(sumK);
    }
}
