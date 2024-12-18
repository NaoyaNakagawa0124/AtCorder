using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int Q = int.Parse(readline[1]);

        string S = Console.ReadLine();

        int step = 0;
        int counter = 0;
        bool[] isrelative = new bool[N];

        for(int i = 0; i < N; i++)
        {
            if(S[i] == 'A' && step == 0)
            {
                step++;
            }
            else if(S[i] == 'B' && step == 1)
            {
                step++;
            }
            else if(S[i] == 'C' && step == 2)
            {
                counter++;
                step = 0;
                isrelative[i - 2] = true;
                isrelative[i - 1] = true;
                isrelative[i] = true;
            }
            else
            {
                step = 0;
            }
        }
        
        for(int i = 0; i < Q; i++)
        {
            tmpCounter = 0;
            readline = Console.ReadLine().Split();
            int targetNumber = int.Parse(readline[0]);
            char targetChar = readline[1][0];
            if(targetChar == 'A')
            {
                if(isrelative[targetNumber] == true)
                {
                    tmpCounter++;
                }
                if(i + 2 < N)
                {
                    if(i + 1 < N)
                    {
                        
                    }
                }
            }

        }

    }
}
