using System;
using System.Collections.Generic;
class Program
{
    static int Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int K = int.Parse(readline[1]);
        int queueCount = 0;

        readline = Console.ReadLine().Split();
        int[] R = new int[N];
        for (int i = 0; i < N; i++)
        {
            R[i] = int.Parse(readline[i]);
        }
        
        Queue<List<int>> queue = new Queue<List<int>>();
        List<int> list = new List<int>();

        // 一旦一番最初のリストを追加
        for (int i = 1; i <= R[0]; i++)
        {
            list = new List<int>();
            list.Add(i);
            queue.Enqueue(list);
        }

        for(int i = 1; i < N; i++)
        {
            queueCount = queue.Count;
            for(int j = 0; j < queueCount; j++)
            {
                List<int> tmpList = queue.Dequeue();
                for(int k = 1; k <= R[i]; k++)
                {
                    List<int> addList = new List<int>(tmpList);
                    addList.Add(k);
                    queue.Enqueue(addList);
                }
            }
        }

        // foreach(List<int> tmpList in queue)
        // {
        //     for(int i = 0; i < tmpList.Count; i++)
        //     {
        //         Console.Write(tmpList[i]);
        //         if(i != tmpList.Count - 1)
        //         {
        //             Console.Write(" ");
        //         }
        //     }
        //     Console.WriteLine();
        // }


        queueCount = queue.Count;
        List<List<int>> ansList = new List<List<int>>();
        for(int i = 0; i < queueCount; i++)
        {
            List<int> tmpList = queue.Dequeue();
            int sum = 0;
            for(int j = 0; j < tmpList.Count; j++)
            {
                sum += tmpList[j];
            }
            if(sum % K == 0)
            {
                ansList.Add(tmpList);
            }
        }

        for(int i = 0; i < ansList.Count; i++)
        {
            for(int j = 0; j < ansList[i].Count; j++)
            {
                Console.Write(ansList[i][j]);
                if(j != ansList[i].Count - 1)
                {
                    Console.Write(" ");
                }
            }
            if(i != ansList.Count - 1)
            {
                Console.WriteLine();
            }
        }
        return 0;
    }
}
