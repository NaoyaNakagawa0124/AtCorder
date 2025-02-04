using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string S = Console.ReadLine().Split();
        int N[] = new int[S.Length];

        string numStr = "";

        int[] AlpabetCount = new int[26];
        int[] tmpAlpabetCount = new int[26];
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < S.Length; i++)
        {
            if(int.TryParse(S[i], out int num))
            {
                while(int.TryParse(S[i], out int num))
                {
                    numStr += S[i];
                    i++;
                }
                if(S[i] != "(" || S[i] != ")")
                {
                    
                }
            }
        }
        return 0;
    }
}
