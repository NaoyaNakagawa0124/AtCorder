using System;
class Program
{
    static int Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] readline = Console.ReadLine().Split();
        int[] A = new int[N];
        bool flag = true;
        int times = 0;
        for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(readline[i]);
        }
        while(flag)
        {
            // 配列を昇順ソート
            Array.Sort(A);
            // 配列の順序を反転させる
            Array.Reverse(A);
            A[0]--;
            A[1]--;
            int counter = 0;
            for(int i = 0; i < N; i++)
            {
                if(A[i] <= 0)
                {
                    counter++;
                }
            }
            if(counter >= N - 1)
            {
                flag = false;
            }
            times++;
        }
        Console.WriteLine(times);
        return 0;
    }
}
