using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int  N = int.Parse(readline[0]);
        int Q = int.Parse(readline[1]);

        int[] PigeonPosition = new int[N + 1];
        Dictionary<int, List<int>> PigeonNest = new Dictionary<int, List<int>>();

        for(int i = 0 ; i < N + 1; i++)
        {
            PigeonPosition[i] = i;
            PigeonNest[i] = new List<int>();
            PigeonNest[i].Add(i);
        }

        for(int i = 0; i < Q; i++)
        {
            string[] query = Console.ReadLine().Split();
            int queryType = int.Parse(query[0]);
            if(queryType == 1)
            {
                int pigeonNumber = int.Parse(query[1]);
                int targetNest = int.Parse(query[2]);
                int currentNest = PigeonPosition[pigeonNumber];

                // 今いる巣から鳩を削除
                PigeonNest[currentNest].Remove(pigeonNumber);

                // 移動先の巣に鳩を追加
                PigeonNest[targetNest].Add(pigeonNumber);

                // 鳩の位置情報を更新
                PigeonPosition[pigeonNumber] = targetNest;
            }
            else if(queryType == 2)
            {
                List<int> tmpAList = new List<int>(PigeonNest[int.Parse(query[1])]);
                List<int> tmpBList = new List<int>(PigeonNest[int.Parse(query[2])]);
                foreach(int item in tmpAList)
                {
                    PigeonPosition[item] = int.Parse(query[2]);
                    // Console.WriteLine($"巣{int.Parse(query[1])}から巣{int.Parse(query[2])}に鳩{item}を移動させた");
                }
                foreach(int item in tmpBList)
                {
                    PigeonPosition[item] = int.Parse(query[1]);
                    // Console.WriteLine($"巣{int.Parse(query[2])}から巣{int.Parse(query[1])}に鳩{item}を移動させた");
                }
                PigeonNest[int.Parse(query[2])] = tmpAList;
                PigeonNest[int.Parse(query[1])] = tmpBList;
            }
            else if(queryType == 3)
            {
                Console.WriteLine(PigeonPosition[int.Parse(query[1])]);
            }
            // i回目の操作終了後の各鳩の位置を出力
            // Console.WriteLine(i + 1);
            // for(int j = 0; j < N + 1; j++)
            // {
            //     Console.Write($"{PigeonPosition[j]} ");
            // }
            // Console.WriteLine();
        }
    }
}

