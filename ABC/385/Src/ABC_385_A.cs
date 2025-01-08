using System;
class Program
{
    static int Main()
    {

        string[] readline = Console.ReadLine().Split();

        int A = int.Parse(readline[0]);
        int B = int.Parse(readline[1]);
        int C = int.Parse(readline[2]);

        int AB = A + B;
        int BC = B + C;
        int CA = C + A;

        if(AB ==C)
        {
            Console.WriteLine("Yes");
            return 0;
        }
        else if(BC == A)
        {
            Console.WriteLine("Yes");
            return 0;
        }
        else if(CA == B)
        {
            Console.WriteLine("Yes");
            return 0;
        }
        else if (A == B && B == C)
        {
            Console.WriteLine("Yes");
            return 0;
        }
        Console.WriteLine("No");
        return 0;
    }
}
