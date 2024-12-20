using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] array = new int[N + 1, N + 1];
        array[1, 1] = int.Parse(Console.ReadLine());
        for(int i = 2; i < N + 1; i++)
        {
            string[] readline = Console.ReadLine().Split();
            for(int j = 1; j < i + 1; j++)
            {
                array[i, j] = int.Parse(readline[j - 1]);
                array[j, i] = array[i, j];
            }
        }

        int tmpElement = 1;

        for(int i = 1; i < N + 1; i++)
        {
            tmpElement = array[tmpElement, i];
        }
        Console.WriteLine(tmpElement);
    }
}
