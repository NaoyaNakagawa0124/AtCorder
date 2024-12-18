using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string[] readline = Console.ReadLine().Split();
        int[] nCounter = new int[101];

        for (int i = 0; i < N; i++)
        {
            nCounter[int.Parse(readline[i])]++;
        }

        long trianglePattern = 0; 

        for (int i = 1; i < 101; i++)
        {
            long count = nCounter[i];
            if (count > 2)
            {
                trianglePattern += count * (count - 1) * (count - 2) / 6;
            }
        }

        Console.WriteLine(trianglePattern);
    }
}
