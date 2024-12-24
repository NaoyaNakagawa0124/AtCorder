using System;
class Program
{
    static int Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] readline = Console.ReadLine().Split();
        long[] H = new long[N];
        long tmpNumber = 0;
        long attackTimes = 0;
        long remainder = 0;
        
        for (int i = 0; i < N; i++)
        {
            H[i] = int.Parse(readline[i]);
            attackTimes += H[i] / 5 * 3;
            remainder = H[i] % 5;
            if(remainder != 0)
            {
                if(tmpNumber == 0)
                {
                    if(remainder - 1 <= 0)
                    {
                        attackTimes += 1;
                        tmpNumber = 1;
                    }
                    else if(remainder - 2 <= 0)
                    {
                        attackTimes += 2;
                        tmpNumber = 2;
                    }
                    else
                    {
                        attackTimes += 3;
                        tmpNumber = 0;
                    }
                }
                else if(tmpNumber == 1)
                {
                    if(remainder - 1 <= 0)
                    {
                        attackTimes += 1;
                        tmpNumber = 2;
                    }
                    else if(remainder - 4 <= 0)
                    {
                        attackTimes += 2;
                        tmpNumber = 0;
                    }
                    else
                    {
                        attackTimes += 3;
                        tmpNumber = 1;
                    }
                }
                else if(tmpNumber == 2)
                {
                    if(remainder - 3 <= 0)
                    {
                        attackTimes += 1;
                        tmpNumber = 0;
                    }
                    else if(remainder - 4 <= 0)
                    {
                        attackTimes += 2;
                        tmpNumber = 1;
                    }
                    else
                    {
                        attackTimes += 3;
                        tmpNumber = 2;
                    }
                }
            }
        }
        Console.Write(attackTimes);
        return 0;
    }
}
