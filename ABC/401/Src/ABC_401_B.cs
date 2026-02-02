using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        bool isLogIn = false;
        int errorTimes = 0;
        for (int i = 0; i < N; i++)
        {
            string s = Console.ReadLine();
            if (s == "login")
            {
                isLogIn = true;
            }
            else if (s == "logout")
            {
                isLogIn = false;
            }
            else if (s == "public")
            {

            }
            else if (s == "private")
            {
                if (isLogIn)
                {

                }
                else
                {
                    errorTimes++;
                }
            }
        }
        Console.Write(errorTimes);
    }
}

