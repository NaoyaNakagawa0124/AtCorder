// ===== ABC439 C - 良い整数 解法ポイント =====
// 【問題】x^2 + y^2 = n (0<x<y) と表せる組がちょうど1通りの n を「良い整数」と呼ぶ。
//        N 以下の良い整数を昇順に全列挙する。制約 N <= 10^7。
//
// 【考え方】
//  1. 「ちょうど1通り」が肝。集合(SortedSet)では「表せるか否か」しか分からず、
//     2通り以上で表せる数(例: 65 = 1^2+8^2 = 4^2+7^2)を誤って含めてしまう。
//     → 各 n が何通りで表せるかを「数える」必要がある。
//  2. N<=10^7 と小さいので int[] count を確保し count[n]++ で出現回数を記録。
//     最後に count[n]==1 の n を拾えば、配列の添字が昇順=ソート不要。
//
// 【計算量と性能】
//  - 二重ループ: x,y < sqrt(N) ≒ 3163 なので約 500万回。x固定でyの和は単調増加
//    →N超過で break し無駄を排除。i*i は整数演算で精度・速度とも安全(Math.Powは不可)。
//  - 配列確保+最終走査: O(N)=10^7 だが配列アクセスのみで超軽量。実測 N=10^7 で約0.25秒。
//  - 出力は StringBuilder でまとめる(都度 Console.Write は遅いため)。
//
// 【ハマりどころ】
//  - long のオーバーフロー: x*x は (long)x*x とキャストしてから掛ける。
//  - 良い整数が0個のとき、2行目は空行を出力する仕様。
// =============================================

using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        // count[n] = x^2 + y^2 = n (0<x<y) と表せる通り数。
        // 「良い整数」= ちょうど1通り = count[n] == 1。
        int[] count = new int[N + 1];

        // x^2 + y^2 <= N より x,y は sqrt(N) 未満。
        // x を固定すると y の増加で和は単調増加なので、N を超えたら break できる。
        for (int x = 1; (long)x * x * 2 <= N; x++)
        {
            for (int y = x + 1; ; y++)
            {
                long tmp = (long)x * x + (long)y * y;
                if (tmp > N) break;
                count[tmp]++;
            }
        }

        var sb = new StringBuilder();
        var goods = new List<int>();
        for (int n = 1; n <= N; n++)
        {
            if (count[n] == 1) goods.Add(n);
        }

        sb.Append(goods.Count).Append('\n');
        sb.Append(string.Join(" ", goods));
        Console.WriteLine(sb.ToString());
    }
}

