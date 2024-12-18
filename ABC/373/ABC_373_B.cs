using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string S = Console.ReadLine();
        
        int tmpPosition = 0;
        int counter = 0;
        int[] alphabetPosition  = new int[26]; // AからZまでの文字の位置を記録する alphabetPosition[0] = Aの位置, alphabetPosition[1] = Bの位置

        for(int i = 0; i < S.Length; i++)
        {
            int j = 0;
            while(S[j] != (char)('A' + i))
            {
                j++;
            }
            alphabetPosition[i] = j;
        }

        tmpPosition = alphabetPosition[0];
        for(int i = 1; i < S.Length; i++)
        {
            counter += Math.Abs(tmpPosition - alphabetPosition[i]);
            tmpPosition = alphabetPosition[i];
        }
        Console.Write(counter);
        return 0;
    }
}