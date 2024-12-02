using System;

class Program
{
    static void Main()
    {
        // 最初の入力を取得（NとK）
        string[] inputs = Console.ReadLine().Split();
        int numCards = int.Parse(inputs[0]);
        int targetNumber = int.Parse(inputs[1]);

        int[] numArray = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // この配列は左の要素はi番目の数値について注目し、右にはターゲットナンバーが入る。
        bool[,] reachableList = new bool[numCards + 1, targetNumber + 1]; // 例えばreachableList[i][0]に関しては全てのカードを使用しなければ必ず実現可能。加えて

        for(int i = 0; i < targetNumber + 1; i++)
        {
            reachableList[0, i] = false;
        }

        for(int i = 0; i < numCards + 1; i++)
        {
            reachableList[i , 0] = true;
        }

        for(int i = 1; i < numCards + 1; i++)
        {
            for(int j = 1; j < targetNumber + 1; j++)
            {
                reachableList[i, j] = reachableList[i - 1, j];
                // Console.WriteLine($"reachableList[{i}][{j}]が{reachableList[i, j]}になったよ");
                if(j - numArray[i - 1] >= 0)
                {
                    if(reachableList[i - 1, j - numArray[i - 1]] == true)
                    {
                        // Console.WriteLine($"reachableList[{i}][{j}]をtrueに更新");
                        reachableList[i, j] = true;
                    }
                }
            }
        }
        if(reachableList[numCards, targetNumber])
        {
            Console.Write("Yes");
        }
        else
        {
            Console.Write("No");
        }
    }
}
