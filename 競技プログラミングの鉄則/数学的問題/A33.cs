using System;

class Program
{
    static void Main()
    {
        // 入力の受け取り
        int N = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split();

        // XOR の結果を格納
        long xorResult = 0;

        // 各山の石の数を XOR 演算
        for (int i = 0; i < N; i++)
        {
            long Ai = long.Parse(inputs[i]);
            xorResult ^= Ai;
        }

        // XOR の結果が 0 なら Second の勝ち、それ以外は First の勝ち
        if (xorResult == 0)
        {
            Console.WriteLine("Second");
        }
        else
        {
            Console.WriteLine("First");
        }
    }
}
