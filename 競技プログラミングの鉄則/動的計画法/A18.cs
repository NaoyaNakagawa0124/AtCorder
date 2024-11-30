using System;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());

        int[] numCards = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] targetNumber = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // まずはその地点までたどり着けるかどうかの2次元配列を用意しよう
        // この配列は左の要素はi番目の数値について注目し、右にはターゲットナンバーが入る。
        bool[,] reachableList = new bool[targetNumber, targetNumber]; // 例えばreachableList[i][0]に関しては全てのカードを使用しなければ必ず実現可能。加えて

        for(int i = 0; i < targetNumber; i++)
        {
            
        }

        // 各部屋にたどり着くための最短日数の配列を用意
        int[] shortestPathDays = new int[N];
        shortestPathDays[0] = 0;
        shortestPathDays[1] = stepOne[0];

         // 一個前の部屋を格納する配列
        int[] previousRoom = new int[N];
        previousRoom[0]  = -1;
        previousRoom[1] = 0;
        
        // 3部屋目からの計算はここでやる
        for(int i = 2; i < N; i++)
        {
            if(shortestPathDays[i - 2] + stepTwo[i - 2] > shortestPathDays[i - 1] + stepOne[i - 1])
            {
                shortestPathDays[i] = shortestPathDays[i - 1] + stepOne[i - 1];
                previousRoom[i] = i - 1;
            }
            else
            {
                shortestPathDays[i] = shortestPathDays[i - 2] + stepTwo[i - 2];
                previousRoom[i] = i - 2;
            }
        }

        int counter = N - 1;
        while(previousRoom[counter] != -1)
        {
            searchList.Add(counter + 1);
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
