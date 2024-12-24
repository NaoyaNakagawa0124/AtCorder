using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] readline = Console.ReadLine().Split();
        int A = int.Parse(readline[0]);
        int B = int.Parse(readline[1]);

        if(A - B == 0)
        {
            Console.WriteLine(1);
            return 0;
        }

        if((A - B) % 2 == 0)
        {
            Console.WriteLine(3);
        }
        else
        {
            Console.WriteLine(2);
        }
        return 0;
    }
}