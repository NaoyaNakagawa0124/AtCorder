using System;

class Program
{
    static void Main()
    {
        var line = Console.ReadLine().Split();
        int N = int.Parse(line[0]);
        int K = int.Parse(line[1]);

        int[] A = new int[N];
        int[] B = new int[N];

        for (int i = 0; i < N; i++)
        {
            line = Console.ReadLine().Split();
            A[i] = int.Parse(line[0]);
            B[i] = int.Parse(line[1]);
        }

        int ans = 1; // 最低1人は選べるはず(全員が可能でなくても、個人は選べる)

        // O(N^3) 全探索
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                int x_min = A[i];
                int x_max = A[i] + K;
                int y_min = B[j];
                int y_max = B[j] + K;

                int count = 0;
                for (int m = 0; m < N; m++)
                {
                    if (A[m] >= x_min && A[m] <= x_max &&
                        B[m] >= y_min && B[m] <= y_max)
                    {
                        count++;
                    }
                }
                if (count > ans)
                    ans = count;
            }
        }

        Console.WriteLine(ans);
    }
}
