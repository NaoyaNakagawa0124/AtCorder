using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        long N = long.Parse(Console.ReadLine());
        long tmp = N;

        List<long> loop_list = new List<long>();
        bool isHappy = false;

        while(true)
        {
            long sum = 0;
            long t = tmp;
            while(t > 0)
            {
                long d = t % 10;
                sum += d * d;
                t /= 10;
            }
            tmp = sum;

            if(tmp == 1)
            {
                isHappy = true;
                break;
            }
            if(loop_list.Contains(tmp))
            {
                break;
            }
            else
            {
                loop_list.Add(tmp);
            }
        }
        if(isHappy)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

