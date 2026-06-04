using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int X = int.Parse(readline[1]);

        readline = Console.ReadLine().Split();

        int res_num = int.Parse(readline[0]);
        Console.WriteLine($"0 {res_num}");

        for (int i = 1; i < readline.Length; i++)
        {
            int tmp = int.Parse(readline[i]);
            if (Math.Abs(tmp - res_num) >= X)
            {
                Console.WriteLine($"{i} {tmp}");
                res_num = int.Parse(readline[i]);
            }
        }
    }
}

