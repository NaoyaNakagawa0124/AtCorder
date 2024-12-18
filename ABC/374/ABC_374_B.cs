using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string S = Console.ReadLine();
        string T = Console.ReadLine();

        for(int i = 0; i < Math.Min(S.Length, T.Length); i++)
        {
            if(S[i] != T[i])
            {
                Console.WriteLine(i + 1);
                return 0;
            }
        }
        if(S.Length != T.Length)
        {
            Console.Write(Math.Min(S.Length, T.Length) + 1);
        }
        else
        {
            Console.WriteLine(0);
        }
        return 0;
    }
}