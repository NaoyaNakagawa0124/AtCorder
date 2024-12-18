using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int N = input[0];
        int M = input[1];

        (int L, int R)[] intervals = new (int, int)[N];
        for (int i = 0; i < N; i++)
        {
            var lr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            intervals[i] = (lr[0], lr[1]);
        }

        // Lでソート
        Array.Sort(intervals, (a,b)=> a.L.CompareTo(b.L));

        // f(l) = L_i≥lを満たす区間のR_iの最小値
        // 存在しなければ f(l)=M+1
        // lを大きい方から小さい方へ走査し、対応する区間を追加していく
        long[] f = new long[M+1];
        for (int i = 0; i <= M; i++) f[i] = M+1; // 初期値M+1で埋める

        int p = N-1; // intervalsの末尾から見る(Lが大きい順)
        int minR = M+1;
        for (int l = M; l >= 1; l--)
        {
            // L_i ≥ l となる区間を追加
            while (p >= 0 && intervals[p].L >= l)
            {
                if (intervals[p].R < minR)
                    minR = intervals[p].R;
                p--;
            }
            f[l] = minR;
        }

        // 答えの計算
        // f(l)=M+1なら任意のr≥lでOKなので M-l+1 個
        // f(l)<=Mなら rはlからf(l)-1までなので f(l)-l 個
        long answer = 0;
        for (int l = 1; l <= M; l++)
        {
            if (f[l] == M+1)
            {
                answer += (M - l + 1);
            }
            else
            {
                if (f[l] > l) // f(l)-lが正
                {
                    answer += (f[l] - l);
                }
                // f(l) ≤ l の場合は、制約が厳しすぎて0個
            }
        }

        Console.WriteLine(answer);
    }
}


// using System;
// class Program
// {
//     static int Main()
//     {
//         // 文字数を読み取る
//         int string_length = int.Parse(Console.ReadLine());

//         int counter = 0;
//         int max = 0;
//         int j = 0;
//         int k = 0;
//         bool flag = true;
//         bool isDuplicate = false;

//         // 任意の文字列
//         string[] target_string = Console.ReadLine().Split();
//         for(int i = 0 ; i < string_length - 1; i++)
//         {
//             if(target_string[i] == target_string[i + 1])
//             {
//                 counter += 2;
//                 j = i;
//                 while(flag)
//                 {
//                     k = i;
//                     j = j + 2;
//                     if(j > string_length - 2)
//                     {
//                         flag = false;
//                     }
//                     else if(target_string[j] == target_string[j + 1])
//                     {
//                         while(k < j)
//                         {
//                             if(target_string[k] == target_string[j])
//                             {
//                                 isDuplicate = true;
//                                 flag = false;
//                             }
//                             k += 2;
//                         }
//                         if(isDuplicate == false)
//                         {
//                             counter += 2;
//                         }
//                     }
//                     else
//                     {
//                         flag = false;
//                     }
//                 }
//             }
//             if(max < counter)
//             {
//                 max = counter;
//             }

//             if(max > string_length / 2 || max > (string_length - i) * 2)
//             {
//                 Console.WriteLine(max);
//                 return 0;
//             }

//             if(counter != 0 && counter != 2)
//             {
//                 i += counter - 1;
//             }
//             flag = true;
//             isDuplicate = false;
//             counter = 0;
//             j = 0;
//         }
//         Console.WriteLine(max);
//         return 0;
//     }
// }