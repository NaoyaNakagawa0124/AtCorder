// 答えを聞いてみれば確かに～～～と感じる内容だし、実装自体もそこまで難しくないように感じる
// とても面白い内容だった。あと手数の計算は思いつかないので復習必要。

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力を受け取る
        string[] nm = Console.ReadLine().Split();
        long n = long.Parse(nm[0]); // N
        int m = int.Parse(nm[1]);  // M

        var stones = new List<(long x, long a)>();

        string[] xInput = Console.ReadLine().Split();
        string[] aInput = Console.ReadLine().Split();

        for (int i = 0; i < m; i++)
        {
            long x = long.Parse(xInput[i]);
            long a = long.Parse(aInput[i]);
            stones.Add((x, a));
        }

        // 石リストを並べ替え
        stones.Sort((s1, s2) => s1.x.CompareTo(s2.x));
        stones.Add((n + 1, 0)); // 番兵を追加

        long sum = 0;
        long px = 0;
        long num = 1;

        foreach (var (x, a) in stones)
        {
            long L = x - px; // 現在位置と前の位置の距離
            long carry = num - L; // 差分を計算

            if (carry < 0)
            {
                Console.WriteLine(-1);
                return;
            }

            sum += x * a; // 合計距離
            px = x;
            num = carry + a; // 次の状態の石の数
        }

        // 最小操作回数を計算
        long ans = n * (n + 1) / 2 - sum;

        if (num != 0)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(ans);
        }
    }
}


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         string[] readline = Console.ReadLine().Split();
//         int N = int.Parse(readline[0]);
//         int M = int.Parse(readline[1]);

//         int[] numofStone = new int[N];

//         int counter = 0;

//         string[] readline1 = Console.ReadLine().Split();
//         string[] readline2 = Console.ReadLine().Split();

//         for(int i = 0; i < N; i++)
//         {
//             numofStone[i] = 0;
//         }

//         for(int i = 0; i < M; i++)
//         {
//             numofStone[int.Parse(readline1[i])] = int.Parse(readline2[i]);
//             counter += int.Parse(readline2[i]);
//         }

//         if(counter != N)
//         {
//             Console.Write(-1);
//             return 0;
//         }

//         for(int i = 0; i < N; i++)
//         {
//             if(numofStone[i] == 0)
//             {
//                 Console.Write(-1);
//                 return 0;
//             }
//             else if(numofStone == 1)
//             {
//                 continue;
//             }
//             else
//             {
//                 int j = i;
//                 while(j < N && numofStone[j] != 1)
//                 {
//                     j++;
//                 }
//                 if()
//             }
//         }
        
//         }

//         // 結果を出力
//         Console.WriteLine(new string(result.ToArray()));
//     }
// }