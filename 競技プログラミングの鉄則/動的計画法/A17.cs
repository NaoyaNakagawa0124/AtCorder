using System;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());

        int[] stepOne = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] stepTwo = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 最短経路を入れていくリスト
        List<int> searchList = new List<int>();


        // 各部屋にたどり着くための最短日数の配列を用意
        int[] shortestPathDays = new int[N];
        shortestPathDays[0] = 0;
        shortestPathDays[1] = stepOne[0];

         // 一個前の部屋を格納する配列
        int[] previousRoom = new int[N];
        previousRoom[0]  = 0;
        previousRoom[1] = 0;
        
        // 3部屋目からの計算はここでやる
        for(int i = 2; i < N; i++)
        {
            if(shortestPathDays[i - 2] + stepTwo[i - 2] > shortestPathDays[i - 1] + stepOne[i - 1])
            {
                shortestPathDays[i] = shortestPathDays[i - 1] + stepOne[i - 1];
                previousRoom[i] = i - 1;
                // Console.WriteLine("１個進むほうが早いみたい！");
                // Console.WriteLine($"previousRoom[{i}]に{i - 1}を代入したよ");
            }
            else
            {
                shortestPathDays[i] = shortestPathDays[i - 2] + stepTwo[i - 2];
                previousRoom[i] = i - 2;
                // Console.WriteLine("2個進むほうが早いみたい！");
                // Console.WriteLine($"previousRoom[{i}]に{i - 2}を代入したよ");
            }
        }

        int counter = N - 1;

        while(counter != 0)
        {
            searchList.Add(counter + 1);
            // Console.WriteLine("何回回ってる?");
            counter = previousRoom[counter];
        }
        searchList.Add(1);

        Console.WriteLine(searchList.Count);

        for(int i = searchList.Count - 1; i > -1; i--)
        {
             // 結果を出力
            Console.Write(searchList[i]);
            if(i != 0)
            {
                Console.Write(" ");
            }
        }
    }
}
