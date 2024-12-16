using System;
class Program
{
    static int Main()
    {
         // 文字列の読み込み
        string[] nq = Console.ReadLine().Split();
        int N = int.Parse(nq[0]);
        int Q = int.Parse(nq[1]);

        int tmpRightPosition = 2;
        int tmpLeftPosition = 1;

        string H = "";
        int T = 0;
        int counter = 0;

        for(int i = 0; i < Q; i++)
        {
            string[] readline = Console.ReadLine().Split();
            H = readline[0];
            T = int.Parse(readline[1]);

            if(H == "R")
            {
                // 左手が右手より右にある場合
                if(tmpRightPosition < tmpLeftPosition)
                {
                    // さらに目標とする番号が左手より右にある場合 
                    if(tmpLeftPosition < T)
                    {
                        // この時は左回転が必要
                        counter += N - (Math.Abs(tmpRightPosition - T));
                        tmpRightPosition = T;
                    }
                    // 目標とする番号が左手より左にある場合
                    else
                    {
                        // この時は右回転が必要
                        counter += T - tmpRightPosition;
                        tmpRightPosition = T;
                    }
                }

                // 左手が右手より左にある場合
                else
                {
                    // さらに目標とする番号が左手より左にある場合
                    if(tmpRightPosition < T)
                    {
                        // この時は必ず右回転が必要
                        counter += N - (Math.Abs(tmpRightPosition - T));
                        tmpRightPosition = T;
                    }
                    // 目標とする番号が左手より右にある場合
                    else
                    {
                        
                    }
                }
            }
            if(H == "L")
            {
                if(tmpLeftPosition < tmpRightPosition && tmpRightPosition < T && tmpLeftPosition != T)
                {
                    counter += N - (T - tmpLeftPosition);
                    tmpLeftPosition = T;
                }
                else
                {
                    if(T < tmpLeftPosition)
                    {
                        counter += N - (Math.Abs(tmpLeftPosition - T));
                        tmpLeftPosition = T;
                    }
                    else
                    {
                        counter += N - (Math.Abs(tmpLeftPosition - T));
                        tmpLeftPosition = T;
                    }
                }
            }
            Console.WriteLine($"{i + 1} {counter}");
        }
        Console.WriteLine(counter);
        return 0;
    }
}