using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 文字列の読み込み
        int N = int.Parse(Console.ReadLine());
        string[] readLine = Console.ReadLine().Split();
        int[] A = new int[readLine.Length];
        for (int i = 0; i < readLine.Length; i++)
        {
            A[i] = int.Parse(readLine[i]);
        }
        long kagamimotiNumber = 0;
        for(int i = 0; i < N; i++)
        {
            //Console.WriteLine($"{i + 1}回目の処理を行っている。");
            kagamimotiNumber += BinarySearchRank(A, A[i]/2);
            //Console.WriteLine(kagamimotiNumber);
        }
        Console.Write(kagamimotiNumber);
        return 0;
    }

    static long BinarySearchRank(int[] sortedList, int target)
    {
        int left = 0;
        int right = sortedList.Length - 1;
        int mid = (left + right) / 2;
        long result = 0;

        while (left <= right)
        {
            if(sortedList[mid] > target)
            {
                //Console.WriteLine($"{target}以下でないので右側を{mid - 1}にずらす。");
                right = mid - 1;
            }
            else if(sortedList[mid] <= target)
            {
                //Console.WriteLine($"{target}より大きくないので左側を{mid + 1}にずらす。");
                left = mid + 1;
                result = mid + 1;
            }
            mid = (left + right) / 2;
        }
        return result; 
    }
}
