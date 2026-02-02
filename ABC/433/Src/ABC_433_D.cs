using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] line1 = Console.ReadLine().Split();
        int N = int.Parse(line1[0]);
        long M = long.Parse(line1[1]);
        
        long[] A = Console.ReadLine().Split().Select(long.Parse).ToArray();
        
        // 桁数ごとに{余り:個数}を記録
        var groups = new Dictionary<long, int>[11];
        for (int i = 0; i < 11; i++)
        {
            groups[i] = new Dictionary<long, int>();
        }
        
        // 各Ajを桁数ごとに分類
        foreach (long aj in A)
        {
            int digits = aj.ToString().Length;
            long mod = aj % M;
            
            if (!groups[digits].ContainsKey(mod))
                groups[digits][mod] = 0;
            
            groups[digits][mod]++;
        }
        
        long count = 0;
        
        // 各Aiについて
        foreach (long originalAi in A)
        {
            long ai = originalAi % M;
            
            // 桁数1〜10について
            for (int k = 1; k <= 10; k++)
            {
                ai = (ai * 10) % M;  // aiを10倍していく
                
                // 必要な余りを計算
                long needMod = (M - ai) % M;
                
                // その余りを持つAjの個数を加算
                if (groups[k].ContainsKey(needMod))
                {
                    count += groups[k][needMod];
                }
            }
        }
        
        Console.WriteLine(count);
    }
}