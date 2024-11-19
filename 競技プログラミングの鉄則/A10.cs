// ChatGPTのコード
// 自分のコードでは正解ではあったが、やはり時間が足りなかった
using System;
class Program
{
    static int Main()
    {
        // 部屋数を読み取る
        int numRooms = int.Parse(Console.ReadLine());

        // 各部屋の収容人数を格納
        string[] roomCapacityStr = Console.ReadLine().Split(" ");
        int[] roomCapacity = new int[numRooms];
        for (int i = 0; i < numRooms; i++)
        {
            roomCapacity[i] = int.Parse(roomCapacityStr[i]);
        }

        // 左右の最大収容人数を事前計算
        int[] leftMax = new int[numRooms];
        int[] rightMax = new int[numRooms];

        leftMax[0] = roomCapacity[0];
        for (int i = 1; i < numRooms; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], roomCapacity[i]);
        }

        rightMax[numRooms - 1] = roomCapacity[numRooms - 1];
        for (int i = numRooms - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], roomCapacity[i]);
        }

        // クエリ数を読み取る
        int numQuestions = int.Parse(Console.ReadLine());

        // クエリごとに最大収容人数を計算
        for (int i = 0; i < numQuestions; i++)
        {
            string[] query = Console.ReadLine().Split(" ");
            int workStartDate = int.Parse(query[0]) - 1;
            int workEndDate = int.Parse(query[1]) - 1;

            int maxCapacity = 0;
            if (workStartDate > 0)
            {
                maxCapacity = Math.Max(maxCapacity, leftMax[workStartDate - 1]);
            }
            if (workEndDate < numRooms - 1)
            {
                maxCapacity = Math.Max(maxCapacity, rightMax[workEndDate + 1]);
            }

            Console.WriteLine(maxCapacity);
        }

        return 0;
    }
}

//     using System;
//     using System.Collections.Generic;

//     class Program
//     {
//         static int Main()
//         {
//             // 最も基本的な標準入力の読み込み
//             // まず1行目の読み取り
//             string readLine = Console.ReadLine();
//             int numRooms = int.Parse(readLine);

//             readLine = Console.ReadLine();
//             string[] readLine_split = readLine.Split(" ");
//             int[] roomCapacity = new int[numRooms];

//             // 各部屋の収容可能人数を格納
//             for(int i = 0; i < numRooms; i++)
//             {
//                 roomCapacity[i] = int.Parse(readLine_split[i]);
//             }

//             readLine = Console.ReadLine();
//             int numQuestion = int.Parse(readLine);
//             int workStartDate = 0;
//             int workEndDate = 0;
//             int maxCapacity = 0;

//             // 何行何列かを格納(数値列)
//             for(int i = 0; i < numQuestion; i++)
//             {
//                 readLine = Console.ReadLine();
//                 readLine_split = readLine.Split(" ");
//                 workStartDate = int.Parse(readLine_split[0]) - 1;
//                 workEndDate = int.Parse(readLine_split[1]) - 1;

//                 for(int j = 0; j < numRooms; j++)
//                 {
//                     if((j >= 0 && j < workStartDate && maxCapacity < roomCapacity[j]) || (j > workEndDate && j < numRooms && maxCapacity < roomCapacity[j]))
//                     {
//                         maxCapacity = roomCapacity[j];
//                     }
//                }
//                 Console.WriteLine(maxCapacity);
//                 maxCapacity = 0;
//             }
//             return 0;
//         }
// }