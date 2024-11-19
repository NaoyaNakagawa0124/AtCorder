
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int Main()
        {
            // 最も基本的な標準入力の読み込み
            // まず1行目の読み取り
            string readLine = Console.ReadLine();
            int numRooms = int.Parse(readLine);

            readLine = Console.ReadLine();
            string[] readLine_split = readLine.Split(" ");
            int[] roomCapacity = new int[numRooms];

            // 各部屋の収容可能人数を格納
            for(int i = 0; i < numRooms; i++)
            {
                roomCapacity[i] = int.Parse(readLine_split[i]);
            }

            readLine = Console.ReadLine();
            int numQuestion = int.Parse(readLine);
            int workStartDate = 0;
            int workEndDate = 0;
            int maxCapacity = 0;

            // 何行何列かを格納(数値列)
            for(int i = 0; i < numQuestion; i++)
            {
                readLine = Console.ReadLine();
                readLine_split = readLine.Split(" ");
                workStartDate = int.Parse(readLine_split[0]) - 1;
                workEndDate = int.Parse(readLine_split[1]) - 1;

                for(int j = 0; j < numRooms; j++)
                {
                    if((j >= 0 && j < workStartDate && maxCapacity < roomCapacity[j]) || (j > workEndDate && j < numRooms && maxCapacity < roomCapacity[j]))
                    {
                        maxCapacity = roomCapacity[j];
                    }
                }
                Console.WriteLine(maxCapacity);
                maxCapacity = 0;
            }
            return 0;
        }
}