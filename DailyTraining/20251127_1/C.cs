using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        long A_X = long.Parse(readline[0]);
        long A_Y = long.Parse(readline[1]);

        readline = Console.ReadLine().Split();
        long B_X = long.Parse(readline[0]);
        long B_Y = long.Parse(readline[1]);

        readline = Console.ReadLine().Split();
        long C_X = long.Parse(readline[0]);
        long C_Y = long.Parse(readline[1]);

        long AB_X = Math.Abs(A_X - B_X);
        long AB_Y = Math.Abs(A_Y - B_Y);
        long BC_X = Math.Abs(B_X - C_X);
        long BC_Y = Math.Abs(B_Y - C_Y);
        long CA_X = Math.Abs(C_X - A_X);
        long CA_Y = Math.Abs(C_Y - A_Y);

        if(AB_X * AB_X + AB_Y * AB_Y + BC_X * BC_X + BC_Y * BC_Y == CA_X * CA_X + CA_Y * CA_Y)
        {
            Console.WriteLine("Yes");
            return;
        }
        else if (CA_X * CA_X + CA_Y * CA_Y + BC_X * BC_X + BC_Y * BC_Y == AB_X * AB_X + AB_Y * AB_Y)
        {
            Console.WriteLine("Yes");
            return;
        }   
        else if (AB_X * AB_X + AB_Y * AB_Y + CA_X * CA_X + CA_Y * CA_Y == BC_X * BC_X + BC_Y * BC_Y)
        {
            Console.WriteLine("Yes");
            return;
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

