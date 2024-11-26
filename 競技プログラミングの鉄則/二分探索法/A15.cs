using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        var input = Console.ReadLine();
        int N = int.Parse(input);

        int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] indexList = new int[N];

        int counter = 0;

        List<int> sortedList  = new List<int>();


        foreach (var a in A)
                sortedList.Add(a);

        // CDをソート
        sortedList.Sort();


        // 小さいほうから数えて何番目なのかを記録しておく
        for(int i = 0;  i < sortedList.Length; i++)
        {
            counter++;
            indexList[i] = counter;
            
        }

        int index = 0;
        bool flag = true;
        for(int i = 0;  i < N; i++)
        {
            index = BinarySearch(sortedList, A[i]);
        }
    }

    static int BinarySearch(List<int> sortedList, int target)
    {
        int left = 0, right = sortedList.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (sortedList[mid] == target)
                {
                    while(flag)
                    {
                        if(mid - 1 >= 0)
                        {
                            if(sortedList[mid] == sortedList[mid - 1])
                            {
                                mid = mid -1;
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    return mid;
                }
            else if (sortedList[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
    }
}
