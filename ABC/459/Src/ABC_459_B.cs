using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string readline = Console.ReadLine();

        char tmp = ' ';

        for(int i=0; i < readline.Length; i++)
        {
            if(tmp == ' ')
            {
                if(readline[i] == 'a' || readline[i] == 'b' || readline[i] == 'c')
                {
                    Console.Write(2);
                }
                if(readline[i] == 'd' || readline[i] == 'e' || readline[i] == 'f')
                {
                    Console.Write(3);
                }
                if(readline[i] == 'g' || readline[i] == 'h' || readline[i] == 'i')
                {
                    Console.Write(4);
                }
                if(readline[i] == 'j' || readline[i] == 'k' || readline[i] == 'l')
                {
                    Console.Write(5);
                }
                if(readline[i] == 'm' || readline[i] == 'n' || readline[i] == 'o')
                {
                    Console.Write(6);
                }
                if(readline[i] == 'p' || readline[i] == 'q' || readline[i] == 'r' || readline[i] == 's')
                {
                    Console.Write(7);
                }
                if(readline[i] == 't' || readline[i] == 'u' || readline[i] == 'v')
                {
                    Console.Write(8);
                }
                if(readline[i] == 'w' || readline[i] == 'x' || readline[i] == 'y' || readline[i] == 'z')
                {
                    Console.Write(9);
                }
            }
            tmp = readline[i];
        }
    }
}

