using System;
class Program
{
    static int Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int K = int.Parse(readline[1]);

        readline = Console.ReadLine().Split();
        int[] A = new int[N];

        for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(readline[i]);
        }

        for(int i = N - K; i < N; i++)
        {        
            Console.Write(A[i]);
            Console.Write(" ");
        }

        for(int i = 0; i < N - K; i++)
        {
            Console.Write(A[i]);
            if(i != N - K - 1)
            {
                Console.Write(" ");
            }
        }
        return 0;
    }
}
