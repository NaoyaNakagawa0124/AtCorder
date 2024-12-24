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

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int tmpL = 0;
        int tmpR = 0;
        int tmpFatigue = 0;

        for(int i = 0; i < N; i++)
        {
            string[] readline = Console.ReadLine().Split();
            if(readline[1] == "L")
            {
                if(tmpL == 0)
                {
                    tmpL = int.Parse(readline[0]);
                }
                else
                {
                    tmpFatigue += Math.Abs(int.Parse(readline[0]) - tmpL);
                    tmpL = int.Parse(readline[0]);
                }
            }
            else
            {
                if(tmpR == 0)
                {
                    tmpR = int.Parse(readline[0]);
                }
                else
                {
                    tmpFatigue += Math.Abs(tmpR - int.Parse(readline[0]));
                    tmpR = int.Parse(readline[0]);
                }
            }
        }
        Console.WriteLine(tmpFatigue);
    }
}
