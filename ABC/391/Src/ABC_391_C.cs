using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] S = Console.ReadLine().Split();
        int N = int.Parse(S[0]);
        int Q = int.Parse(S[1]);

        // 鳩の巣
        int[] Nest = new int[N];

        // N番目の鳩の位置
        int[] pigeon_Position = new int[N];

        int ans = 0;

        for(int i = 0; i < N; i++)
        {
            Nest[i] = 1;
            pigeon_Position[i] = i;
        }

        for(int i = 0; i < Q; i++)
        {
            string[] queries = Console.ReadLine().Split();
            if(queries[0] == "1")
            {
                if(Nest[int.Parse(queries[2]) - 1] == 1)
                {
                    ans++;
                }
                if(Nest[pigeon_Position[int.Parse(queries[1]) - 1]] == 2)
                {
                    ans--;
                }
                
                // ここで鳩の巣の数を更新 移動前の鳩の位置の巣を減らす
                Nest[pigeon_Position[int.Parse(queries[1]) - 1]]--;

                // ここで鳩の巣の数を更新 移動後の鳩の位置の巣を増やす
                Nest[int.Parse(queries[2]) - 1]++;

                // ここで鳩の位置を更新
                pigeon_Position[int.Parse(queries[1]) - 1] = int.Parse(queries[2]) - 1;                
            }
            else
            {
                Console.WriteLine(ans);
            }
        }
        return 0;
    }
}
