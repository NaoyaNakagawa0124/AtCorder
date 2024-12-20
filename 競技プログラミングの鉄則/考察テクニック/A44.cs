using System;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        
        int N = int.Parse(readline[0]);
        int Q = int.Parse(readline[1]);

        int[] array = new int[N];
        bool isReverse = false;

        for(int i = 0; i < N; i++)
        {
            array[i] = i + 1;
        }

        for(int i = 0; i < Q; i++)
        {
            readline = Console.ReadLine().Split();

            if(readline.Length == 1)
            {
                isReverse = !isReverse;
            }
            else if(readline.Length == 2)
            {
                if(isReverse)
                {
                    Console.WriteLine(array[N - int.Parse(readline[1])]);
                }
                else
                {
                    Console.WriteLine(array[int.Parse(readline[1]) - 1]);
                }
            }
            else
            {
                if(isReverse)
                {
                    array[N - int.Parse(readline[1])] = int.Parse(readline[2]);
                }
                else
                {
                    array[int.Parse(readline[1]) - 1] = int.Parse(readline[2]);
                }
            }
        }
    }
}
