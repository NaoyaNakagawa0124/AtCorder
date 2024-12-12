using System;

class Program
{
    static void Main()
    {
        // 2つの整数を入力
        string[] readline = Console.ReadLine().Split();
        long N = long.Parse(readline[0]);
        long A = long.Parse(readline[1]);
        long B = long.Parse(readline[2]);

        bool[] enemyLose = new bool[N + 1];
        for(int i = 0; i < N + 1; i++)
        {
            enemyLose[i] = false;
        }
        enemyLose[A] = true;
        enemyLose[B] = true;
        
        for(long i = 0; i < N + 1; i++)
        {
            if(i - B >= 0 && !enemyLose[i - B] || !enemyLose[i - A])
            {
                enemyLose[i] = true;
            }
        }
        if(enemyLose[N])
        {
            Console.Write("First");
        }
        else
        {
            Console.Write("Second");
        }
    }
}
