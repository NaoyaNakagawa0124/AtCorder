using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力を取得
        string[] inputs = Console.ReadLine().Split();
        int N = int.Parse(inputs[0]);
        int K = int.Parse(inputs[1]);
        string S = Console.ReadLine();

        // Run-Length Encoding（RLE）を使って1の塊を特定する
        List<(char c, int length)> rle = new List<(char, int)>();
        char currentChar = S[0];
        int count = 1;

        for (int i = 1; i < N; i++)
        {
            if (S[i] == currentChar)
            {
                count++;
            }
            else
            {
                rle.Add((currentChar, count));
                currentChar = S[i];
                count = 1;
            }
        }
        rle.Add((currentChar, count)); // 最後の塊を追加

        // K番目の1の塊をK-1番目の1の塊の直後に移動
        int oneCount = 0;
        int indexK = -1, indexKMinus1 = -1;

        for (int i = 0; i < rle.Count; i++)
        {
            if (rle[i].c == '1')
            {
                oneCount++;
                if (oneCount == K - 1)
                {
                    indexKMinus1 = i;
                }
                if (oneCount == K)
                {
                    indexK = i;
                    break;
                }
            }
        }

        // K番目の1の塊をK-1番目の1の塊の直後に移動
        rle[indexKMinus1] = ('1', rle[indexKMinus1].length + rle[indexK].length);

        if (indexK + 1 < rle.Count && rle[indexK + 1].c == '0')
        {
            rle[indexK + 1] = ('0', rle[indexK + 1].length + rle[indexK].length);
        }
        else if (indexK + 1 == rle.Count || rle[indexK + 1].c == '1')
        {
            rle.Insert(indexK + 1, ('0', rle[indexK].length));
        }

        rle.RemoveAt(indexK);

        // 文字列を再構築
        List<char> result = new List<char>();
        foreach (var (c, length) in rle)
        {
            for (int i = 0; i < length; i++)
            {
                result.Add(c);
            }
        }

        // 結果を出力
        Console.WriteLine(new string(result.ToArray()));
    }
}




// 実装自体はできていてTLEになっているだけで正解はしているのでまぁこれはこれで自力でできたらよく頑張ったと思う
// using System;
// class Program
// {
//     static int Main()
//     {
//         // 文字列の読み込み
//         string[] readline = Console.ReadLine().Split();
//         int N = int.Parse(readline[0]);
//         int K = int.Parse(readline[1]);

//         // 結果を格納するリスト
//         List<List<string>> ansZero = new List<List<string>>();
//         List<List<string>> ansOne = new List<List<string>>();
//         List<string> tmpList = new List<string>();

//         // 文字列の読み込み
//         char[] target_string = Console.ReadLine().ToCharArray();
//         string tmpNumber = "";
//         string firstNumber = "";

//         tmpList.Add(target_string[0].ToString());
//         tmpNumber = target_string[0].ToString();
//         firstNumber = target_string[0].ToString();

//         for(int i = 1; i < target_string.Length; i++)
//         {
//             if(tmpNumber == target_string[i].ToString())
//             {
//                 // Console.WriteLine($"{i + 1}文字目は前の文字と一緒");
//                 tmpList.Add(target_string[i].ToString());
//                 // Console.WriteLine($"tmpListを更新");
//                 // Console.WriteLine(string.Join("", tmpList));
//             }
//             else
//             {
//                 if(tmpNumber == "0")
//                 {
//                     // Console.WriteLine($"{i + 1}文字目は1だけどそれまでは0だったからansZeroにtmpListを代入するよ");
//                     // Console.WriteLine("下が代入するtmpListだよ");
//                     // Console.WriteLine(string.Join("", tmpList));
//                     ansZero.Add(new List<string>(tmpList));
//                     // Console.WriteLine("下が現在のansZeroだよ");
//                     // foreach (var list in ansZero)
//                     // {
//                     //     foreach (var item in list)
//                     //     {
//                     //         Console.Write(item + "");
//                     //     }
//                     //     Console.WriteLine("");
//                     // }
//                     // Console.WriteLine("");
//                     tmpList.RemoveAll(s => s.Contains('0'));
//                     tmpList.Add(target_string[i].ToString());
//                     tmpNumber = "1";
//                 }
//                 else
//                 {
//                     // Console.WriteLine($"{i + 1}文字目は0だけどそれまでは1だったからansOneにtmpListを代入するよ");
//                     // Console.WriteLine("下が代入するtmpListだよ");
//                     // Console.WriteLine(string.Join("", tmpList));
//                     ansOne.Add(new List<string>(tmpList));
//                     // Console.WriteLine("下が現在のansOneだよ");
//                     // foreach (var list in ansOne)
//                     // {
//                     //     foreach (var item in list)
//                     //     {
//                     //         Console.Write(item + " ");
//                     //     }
//                     //     Console.WriteLine("");
//                     // }
//                     // Console.WriteLine("");
//                     tmpList.RemoveAll(s => s.Contains('1'));
//                     tmpList.Add(target_string[i].ToString());
//                     tmpNumber = "0";
//                 }
//             }
//         }

//         if(tmpNumber == "1")
//         {
//             ansOne.Add(new List<string>(tmpList));
//         }
//         else
//         {
//             ansZero.Add(new List<string>(tmpList));
//         }

//         ansOne[K - 2].AddRange(ansOne[K - 1]);
//         ansOne[K - 1].RemoveAll(s => s.Contains('1'));

//         List<string> finalList = new List<string>();

//         if(firstNumber == "0")
//         {
//             while((ansZero?.Count > 0) || (ansOne?.Count > 0))
//             {
//                 if(ansZero?.Count > 0)
//                 {
//                     finalList.AddRange(ansZero[0]);
//                     ansZero.RemoveAt(0);
//                 }
//                 if(ansOne?.Count > 0)
//                 {
//                     finalList.AddRange(ansOne[0]);
//                     ansOne.RemoveAt(0);
//                 }
//             }
//         }
//         else
//         {
//             while((ansZero?.Count > 0) ||  (ansOne?.Count > 0))
//             {
//                 if(ansOne?.Count > 0)
//                 {
//                     finalList.AddRange(ansOne[0]);
//                     ansOne.RemoveAt(0);
//                 }

//                 if(ansZero?.Count > 0)
//                 {
//                     finalList.AddRange(ansZero[0]);
//                     ansZero.RemoveAt(0);
//                 }
//             }
//         }

//         Console.Write(string.Join("",finalList));
//         return 0;
//     }
// }