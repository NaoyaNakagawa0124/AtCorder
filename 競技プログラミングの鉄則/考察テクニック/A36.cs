using System;
using System.Linq;

class Program
{
    static int Main()
    {
        // 2つの整数を入力
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int K = int.Parse(readline[1]);

        if(2 * N - 2 > K)
        {
            Console.WriteLine("No");
            return 0;
        }

        if((K - (2 * N - 2)) % 2 == 0)
        {
            Console.WriteLine("Yes");
            return 0;
        }
        else
        {
            Console.WriteLine("No");
            return 0;
        }
    }
}
