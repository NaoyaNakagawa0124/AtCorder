using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] line = Console.ReadLine().Split();
        long[] A = new long[N];
        for (int i = 0; i < N; i++)
        {
            A[i] = long.Parse(line[i]);
        }

        long product = A[0] * A[N - 1];
        for (int i = 0; i <= (N - 1) / 2; i++)
        {
            int j = N - 1 - i;
            if (i == j)
            {
                if (A[i] * A[i] != product)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            else
            {
                if (A[i] * A[j] != product)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
        }

        Console.WriteLine("Yes");
    }
}
