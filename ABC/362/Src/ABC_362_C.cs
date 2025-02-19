using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        long[] L = new long[N];
        long[] R = new long[N];
        long[] mean = new long[N];

        long min = 0;
        long max = 0;
        long mid = 0;

        List<long> list = new List<long>();

        for(int i = 0; i < N; i++)
        {
            string[] readline = Console.ReadLine().Split();
            L[i] = long.Parse(readline[0]);
            R[i] = long.Parse(readline[1]);
            mean[i] = (L[i] + R[i]) / 2;

            min += L[i];
            max += R[i];
            mid += mean[i];
        }

        if(min > 0 || max < 0)
        {
            Console.WriteLine("No");
            return;
        }

        bool flag = false;

        if(mid > 0)
        {
            for(int i = 0; i < N; i++)
            {
                if(!flag)
                { 
                    if(mid -(mean[i] - L[i]) >= 0)
                    {
                        mid -= (mean[i] - L[i]);
                        list.Add(L[i]);
                    }
                    else
                    {
                        list.Add(mean[i] - mid);
                        flag = true;
                    }
                }
                else
                {
                    list.Add(mean[i]);
                }
            }
        }

        else
        {
            for(int i = 0; i < N; i++)
            {
                if(!flag)
                {
                    if(mid + (R[i] - mean[i]) <= 0)
                    {
                        mid += (R[i] - mean[i]);
                        list.Add(R[i]);
                    }
                    else
                    {
                        flag = true;
                        list.Add(mean[i] - mid);
                    }
                }
                else
                {
                    list.Add(mean[i]);
                }
            }
        }
        Console.WriteLine("Yes");
        for(int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);
            Console.Write(" ");
        }
    }
}

