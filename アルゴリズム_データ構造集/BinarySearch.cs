using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        var input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] B = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] C = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] D = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 結果の出力
        Console.WriteLine(CanSumToK(N, K, A, B, C, D));
    }

    static string CanSumToK(int N, int K, int[] A, int[] B, int[] C, int[] D)
    {
        // ABとCDの組み合わせをそれぞれ計算
        List<int> AB = new List<int>();
        List<int> CD = new List<int>();

        foreach (var a in A)
            foreach (var b in B)
                AB.Add(a + b);

        foreach (var c in C)
            foreach (var d in D)
                CD.Add(c + d);

        // CDをソート
        CD.Sort();

        // ABの各要素について、K - x がCDにあるかを二分探索で確認
        foreach (var ab in AB)
        {
            int target = K - ab;
            if (BinarySearch(CD, target))
            {
                return "Yes";
            }
        }

        return "No";
    }

    static bool BinarySearch(List<int> sortedList, int target)
    {
        int left = 0, right = sortedList.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (sortedList[mid] == target)
                return true;
            else if (sortedList[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}
