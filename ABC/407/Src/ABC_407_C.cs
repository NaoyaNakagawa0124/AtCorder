using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string readline = Console.ReadLine();
        int counter = 0;
        int itaration = 0;
        for (int i = readline.Length - 1; i >= 0; i--)
        {
            int num = int.Parse(readline[i].ToString());
            if (num < counter)
            {
                num = num + 10 - counter;
            }
            else
            {
                num = num - counter;
            }
            while (num != 0)
                {
                    num--;
                    counter++;
                    itaration++;
                }
            itaration++;
            counter = counter % 10;
        }
        Console.WriteLine(itaration);
    }
}

