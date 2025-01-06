using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        int K = int.Parse(Console.ReadLine());
        string S = Console.ReadLine();
        string T = Console.ReadLine();

        List<char> SList = new List<char>();
        List<char> TList = new List<char>();
        for(int i = 0; i < S.Length; i++)
        {
            SList.Add(S[i]);
        }
        for(int i = 0; i < T.Length; i++)
        {
            TList.Add(T[i]);
        }

        int OperateTime = 0;

        for(int i = 0; i < Math.Min(SList.Count, TList.Count) - 1; i++)
        {
            if(SList[i] == TList[i])
            {
                continue;
            }
            else
            {
                if(SList.Count == TList.Count)
                {
                    OperateTime++;
                }
                
                else if(SList.Count > TList.Count)
                {
                    SList.RemoveAt(i);
                    OperateTime++;
                    i--;
                }
                else
                {
                    SList.Insert(i, T[i]);
                    OperateTime++;
                }
                if(OperateTime > K)
                {
                    // 与えられた操作可能回数を超えた場合はNoを出力して終了
                    Console.Write("No");
                    return 0;
                }
            }
        }

        // 最後の要素だけ素朴に比較
        if(SList.Count == TList.Count)
        {
            if(SList[SList.Count - 1] != TList[TList.Count - 1])
            {
                OperateTime++;
            }
        }
        else
        {
            OperateTime += Math.Abs(SList.Count - TList.Count);
        }

        // 与えられた操作可能回数を超えた場合はNoを出力して終了
        if(OperateTime > K)
        {
            Console.Write("No");
            return 0;
        }
        Console.Write("Yes");
        return 0;
    }
}
