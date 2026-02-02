using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ulong N = ulong.Parse(Console.ReadLine());

        var seen = new HashSet<ulong>();

        for (ulong b = 1; ; b++)
        {
            ulong b2 = b * b;
            if (b2 > N) break;

            ulong x = b2;
            while (x <= N)
            {
                seen.Add(x);
                if (x <= N / 2)
                    x *= 2;
                else
                    break;
            }
        }

        Console.WriteLine(seen.Count);
    }
}
