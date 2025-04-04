// 最初はContinueの力に任せて全パターン列挙したけどせっかくなのでbit全探索に置き換えてみる
using System;
using System.Collections.Generic;
class Program
{
    static int Main()
    {

        string[] readline = Console.ReadLine().Split();
        int[] Scores = new int[readline.Length];
        for (int i = 0; i < readline.Length; i++)
        {
            Scores[i] = int.Parse(readline[i]);
        }

        List<(string, int)> ans = new List<(string, int)>();

        // bit全探索
        // s は 0～(2^N-1) まで全部分集合を表す
        for(int i = 1; i < (1 << Scores.Length); i++) // この書き方が少し難しいけど1を左にScore.Lengthビット分ずらした回数未満のループという意味になっている
        {
            string s = "";
            int tmpSum = 0;
            for (int j = 0; j < Scores.Length; j++) // ここはbitの論理積を取るので動かす回数はScores.Length回となる
            {
                if (((i >> j) & 1) == 1) // これはiを右にjビット分だけずらした結果そのビットが1ならtrueになるというもの
                {
                    s += ((char)('A' + j)).ToString(); //ここも書き方難しいけどAを基準にjだけ進めたときのアルファベットという意味
                    tmpSum += Scores[j];
                }
            }
            ans.Add((s, tmpSum));
        }
        // ここではソートしないといけないのでソートする
        ans.Sort((x, y) =>
        {
            
            // xとyはansの要素の中から、内部アルゴリズムによって比較が必要になったときに渡される２つの要素です。

            // 1. まず、x.Item2とy.Item2を比較します。
            //    CompareToメソッドは、(a.CompareTo(b))で、a<bなら負、a==bなら0、a>bなら正の値を返します。
            //    y.Item2.CompareTo(x.Item2) としているので、
            //    y.Item2 > x.Item2 のとき c > 0
            //    y.Item2 = x.Item2 のとき c = 0
            //    y.Item2 < x.Item2 のとき c < 0
            //    これで「大きな数字ほど前に来る」順序を実現します。

            int c = y.Item2.CompareTo(x.Item2);

            // 2. もし c != 0 (つまりItem2同士で大小がついた場合)は、その比較結果 c を戻します。
            //    これで数値が異なる場合は、数値が大きい方を先、すなわち降順で並ぶようになります。
            if (c != 0) return c;

            // 3. ここに来るのは、x.Item2とy.Item2が等しい場合です。
            //    このときはItem1(文字列)同士を比較して、辞書順(昇順)にします。
            //    CompareToを普通に呼べば、'A' < 'B'のような順で小さい方が先にきます。
            return x.Item1.CompareTo(y.Item1);

            // 要するにx, yの大小関係の決め方をラムダ式で定義している
        });

        foreach(var item in ans)
        {
            Console.WriteLine(item.Item1);
        }
        return 0;
    }
}

// using System;
// using System.Collections.Generic;
// class Program
// {
//     static int Main()
//     {

//         string[] readline = Console.ReadLine().Split();
//         int A = int.Parse(readline[0]);
//         int B = int.Parse(readline[1]);
//         int C = int.Parse(readline[2]);
//         int D = int.Parse(readline[3]);
//         int E = int.Parse(readline[4]);

//         List<(int, string)> ans = new List<(int, string)>();

//         ans.Add((A, "A"));
//         ans.Add((B, "B"));
//         ans.Add((C, "C"));
//         ans.Add((D, "D"));
//         ans.Add((E, "E"));
//         ans.Add((A + B, "AB"));
//         ans.Add((A + C, "AC"));
//         ans.Add((A + D, "AD"));
//         ans.Add((A + E, "AE"));
//         ans.Add((B + C, "BC"));
//         ans.Add((B + D, "BD"));
//         ans.Add((B + E, "BE"));
//         ans.Add((C + D, "CD"));
//         ans.Add((C + E, "CE"));
//         ans.Add((D + E, "DE"));
//         ans.Add((A + B + C, "ABC"));
//         ans.Add((A + B + D, "ABD"));
//         ans.Add((A + B + E, "ABE"));
//         ans.Add((A + C + D, "ACD"));
//         ans.Add((A + C + E, "ACE"));
//         ans.Add((A + D + E, "ADE"));
//         ans.Add((B + C + D, "BCD"));
//         ans.Add((B + C + E, "BCE"));
//         ans.Add((B + D + E, "BDE"));
//         ans.Add((C + D + E, "CDE"));
//         ans.Add((A + B + C + D, "ABCD"));
//         ans.Add((A + B + C + E, "ABCE"));
//         ans.Add((A + B + D + E, "ABDE"));
//         ans.Add((A + C + D + E, "ACDE"));
//         ans.Add((B + C + D + E, "BCDE"));
//         ans.Add((A + B + C + D + E, "ABCDE"));

//         ans.Sort((x, y) =>
//         {
//             int primaryComparison = y.Item1.CompareTo(x.Item1); 
//             if (primaryComparison == 0)
//             {
//                 return StringComparer.Ordinal.Compare(x.Item2, y.Item2); 
//             }
//             return primaryComparison;
//         });

//         foreach (var item in ans)
//         {
//             Console.WriteLine(item.Item2);
//         }
//         return 0;
//     }
// }