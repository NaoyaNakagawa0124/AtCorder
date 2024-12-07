using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力を受け取る
        var inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        // 結果を格納するリスト
        List<List<int>> ans = new List<List<int>>();

        // 再帰を呼び出すメソッド
        GenerateSequences(new List<int>(), n, m, ans);

        // 結果を出力
        Console.WriteLine(ans.Count);
        foreach (var sublist in ans)
        {
            Console.WriteLine(string.Join(" ", sublist));
        }
    }

    static void GenerateSequences(List<int> current, int n, int m, List<List<int>> ans)
    {
        // ベースケース: 長さがnに達したら結果を保存
        if (current.Count == n)
        {
            ans.Add(new List<int>(current)); // 現在のリストをコピーして保存
            return;
        }

        // 次に追加する値を決める
        int l = 1;
        if (current.Count > 0)
        {
            l = current[^1] + 10; // 現在のリストの最後の値 + 1
        }

        current.Add(l); // 最初の値を追加

        // ここがWhileなのがミソ！これで特定の回数分の再起関数を呼び出している
        while (current[^1] + 10 * (n - current.Count) <= m)
        {
            GenerateSequences(current, n, m, ans); // 再帰呼び出し
            current[^1]++; // 現在のリストの最後の値をインクリメント
        }
        current.RemoveAt(current.Count - 1); // 最後に追加した値を削除
    }
}

// using System;
// class Program
// {
//     static int Main()
//     {
//         // 文字数を読み取る
//         string[] readline = Console.ReadLine().Split();
//         int targetLength = int.Parse(readline[0]);
//         int tagetNumber = int.Parse(readline[1]); 

//         int hundredTargetNumber = tagetNumber / 100;
//         int tenTargetNumber = tagetNumber / 10;
//         int oneTargetNumber = tagetNumber - hundredTargetNumber * 100 - tenTargetNumber * 10;

//         if(oneTargetNumber == 0)
//         {
//             oneTargetNumber = 10;
//         }

//         int i = 1;

//         while(i <= oneTargetNumber)
//         {
//             for(int j = 1; j < oneTargetNumber; j++)
//             {
//                 for(int k = 1; k < oneTargetNumber; k++)
//                 {
//                     for(int l = 0; l < targetLength; l++)
//                     {
                        
//                     }
//                 }
//             }
//         }
//         return 0;
//     }
    
// }