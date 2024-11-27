using System;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());

        int[] stepOne = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] stepTwo = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        

        // ソート済み配列をユニーク化
        int[] uniqueList = RemoveDuplicates(sortedList);

        // 辞書を使わずに順位を割り当てる
        int[] B = new int[N];
        for (int i = 0; i < N; i++)
        {
            // 二分探索で順位を取得
            B[i] = BinarySearchRank(uniqueList, A[i]) + 1;
        }

        // 結果を出力
        Console.WriteLine(string.Join(" ", B));
    }

    // 重複を削除してユニークな配列を返す
   static int[] RemoveDuplicates(int[] array)
{
    int n = array.Length;
    if (n == 0) return new int[0]; // 配列が空の場合は空配列を返す

    int[] uniqueArray = new int[n]; // ユニークな値を格納する配列（最大サイズは元の配列と同じ）
    int index = 0; // ユニークな値の挿入位置を管理

    // 最初の要素をユニーク配列に追加
    uniqueArray[index] = array[0];
    index++; // 次の位置に進む

    // 2番目以降の要素をチェック
    for (int i = 1; i < n; i++)
    {
        if (array[i] != array[i - 1]) // 直前の値と異なる場合のみユニーク配列に追加
        {
            uniqueArray[index] = array[i]; // 現在のインデックスに値を代入
            index++; // インデックスを進める
        }
    }

    // 配列のサイズを調整
    Array.Resize(ref uniqueArray, index);
    return uniqueArray; // ユニーク配列を返す
}


    // 2分探索で順位を取得
    static int BinarySearchRank(int[] sortedList, int target)
    {
        int left = 0, right = sortedList.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (sortedList[mid] == target)
                return mid;
            else if (sortedList[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // 通常ここには到達しない
    }
}
