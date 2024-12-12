using System;

class Program
{
    static void Main()
    {
        // 2つの整数を入力
        string[] readline = Console.ReadLine().Split();
        long a = long.Parse(readline[0]);
        long b = long.Parse(readline[1]);
        
        long divisor = 1000000007;

        long leftover = 1;

        long numerator = a;

        int counter = 1;

        while(b != 0)
        {
            if(b % 2 == 1)
            {
                leftover = leftover * numerator;
                leftover = leftover % divisor;
            }
            b = b / 2;            
            numerator = numerator * numerator;
            numerator = numerator % divisor;
        }
        Console.Write(leftover);
    }
}
