using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int targetNumber = 0;

        for (int i = 0; i < N; i++)
        {
            string[] readline = Console.ReadLine().Split();
            if(readline[0] == "+")
            {
                targetNumber += int.Parse(readline[1]);
                targetNumber = targetNumber % 10000;
            }
            else if(readline[0] == "-")
            {
                targetNumber -= int.Parse(readline[1]);
                if(targetNumber < 0)
                {
                    targetNumber = targetNumber + 10000;
                }
            }
            else
            {
                targetNumber *= int.Parse(readline[1]);
                targetNumber = targetNumber % 10000;
            }
            Console.WriteLine(targetNumber);
        }
    }
}
