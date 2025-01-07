using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] readline = Console.ReadLine().Split();
        string L = readline[0];
        string R = readline[1];

        int[] L_Array = new int[L.Length];
        int[] R_Array = new int[R.Length];

        for(int i = 0; i < L.Length; i++)
        {
            L_Array[i] = int.Parse(L[i].ToString());
        }
        for(int i = 0; i < R.Length; i++)
        {
            R_Array[i] = int.Parse(R[i].ToString());
        }

        long L_SnakeNum = 1;
        long R_SnakeNum = 1;

        long Limit_L = 0;
        long Limit_R = 0;

        // まずLのほうの計算
        for(int i = 1; i < L.Length; i++)
        {
            if(L_Array[i] > L_Array[0])
            {
                int j = i;
                while(j < L.Length)
                {
                    L_Array[j] = L_Array[0] - 1;
                    j++;
                }
            }
        }

        int tmp = 0;
        while(tmp < )
        Console.WriteLine(L_SnakeNum);
        return 0;
    }
}
