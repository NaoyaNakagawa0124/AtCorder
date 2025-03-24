using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();

        int N = int.Parse(readline[0]);
        int M = int.Parse(readline[1]);

        int[] B = new int[N];
        int[] W = new int[M];

        readline = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            B[i] = int.Parse(readline[i]);
        }

        readline = Console.ReadLine().Split();
        for (int i = 0; i < M; i++)
        {
            W[i] = int.Parse(readline[i]);
        }

        List<int> sortedB = B.OrderBy(x => -x).ToList();
        List<int> sortedW = W.OrderBy(x => -x).ToList();

        int tmpMax = 0;
        int tmpBMax = 0;
        int tmpWMax = 0;

        for (int i = 0; i < N; i++)
        {
            int tmpW = tmpWMax;
            // ここでは白色のボールが黒色より少ないときに白色のボールの数でループを回すとindexOutOfRangeエラーが発生するので例外処理。
            if(i <= M - 1)
            {
                tmpW = Math.Max(tmpW, tmpW + sortedW[i]);
            }

            int tmpB = tmpBMax + sortedB[i];

            if(tmpW + tmpB < tmpMax)
            {
                Console.WriteLine(tmpMax);
                return;
            }

            tmpMax = tmpW + tmpB;
            tmpBMax = tmpB;
            tmpWMax = tmpW;
        }

        Console.WriteLine(tmpMax);
        return;
    }
}

