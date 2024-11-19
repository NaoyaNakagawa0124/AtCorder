    // 久しぶりの二分探索.....
    // 少し時間がかかってしまった.......
    
    using System;
    using System.Collections.Generic;

    class Program
    {

        public static int PerformBinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    return mid; // 値が見つかった場合のインデックスを返す
                }
                else if (array[mid] < target)
                {
                    left = mid + 1; // ターゲットが右側にある場合
                }
                else
                {
                    right = mid - 1; // ターゲットが左側にある場合
                }
            }

            return -1; // 値が見つからなかった場合
        }

        static int Main()
        {
            // 最も基本的な標準入力の読み込み
            // まず1行目の読み取り
            string readLine = Console.ReadLine();
            string[] readLine_split = readLine.Split(" ");

            // 配列の要素数、目標の数を格納
            int numElements = int.Parse(readLine_split[0]);
            int targetNumber = int.Parse(readLine_split[1]);

            // 調査する配列の格納
            readLine = Console.ReadLine();
            readLine_split = readLine.Split(" ");

            int[] targetArray = new int[numElements];

            // 配列の各要素を格納
            for(int i = 0; i < numElements; i++)
            {
                targetArray[i] = int.Parse(readLine_split[i]);
            }

            int answer = PerformBinarySearch(targetArray, targetNumber) + 1;

            Console.WriteLine(answer);

            return 0;
        }
}