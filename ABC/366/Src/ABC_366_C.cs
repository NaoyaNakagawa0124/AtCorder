using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        int N = int.Parse(Console.ReadLine());
        int[] Q = new int[1000001];
        int type = 0;
        List<int> list = new List<int>();

        for(int i = 0; i < N; i++)
        {
            string[] S = Console.ReadLine().Split();
            if(S.Length == 2)
            {
                int queryType = int.Parse(S[0]);
                int x = int.Parse(S[1]);
                if(queryType == 1)
                {
                    if(Q[x] == 0)
                    {
                        type++;
                    }
                    Q[x]++;
                }
                else
                {
                    if(Q[x] == 1)
                    {
                        type--;
                    }
                    Q[x]--;
                }
            }
            else
            {
                list.Add(type);
            }
        }

        for(int i = 0; i < list.Count; i++)
        {
            if(i != list.Count - 1)
            {
                Console.WriteLine(list[i]);
            }
            else
            {
                Console.Write(list[i]);
            }
        }
        
        return 0;
    }
}
