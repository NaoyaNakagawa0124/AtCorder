using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] readline = Console.ReadLine().Split();
        int R = int.Parse(readline[0]);
        int G = int.Parse(readline[1]);
        int B = int.Parse(readline[2]);

        string C = Console.ReadLine();

        if(C == "Red")
        {
            if(G > B)
            {
                Console.Write(B);
            }
            else
            {
                Console.Write(G);
            }
        }

        else if(C == "Green")
        {
            if(R > B)
            {
                Console.Write(B);
            }
            else
            {
                Console.Write(R);
            }
        }

        else if(C == "Blue")
        {
            if(R > G)
            {
                Console.Write(G);
            }
            else
            {
                Console.Write(R);
            }
        }
    }
}

