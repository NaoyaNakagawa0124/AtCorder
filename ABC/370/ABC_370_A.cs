using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] readline = Console.ReadLine().Split();
        int L = int.Parse(readline[0]);
        int R = int.Parse(readline[1]);

        if(L == 1 && R == 1)
        {
            Console.WriteLine("Invalid");
        }
        else if(L == 1 && R == 0)
        {
            Console.WriteLine("Yes");
        }
        else if(L == 0 && R == 1)
        {
            Console.WriteLine("No");
        }
        else if(L == 0 && R == 0)
        {
            Console.WriteLine("Invalid");
        }
        return 0;
    }
}