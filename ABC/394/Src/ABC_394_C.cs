using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string S = Console.ReadLine();

        int Wcount = 0;

        string ans = "";

        for(int i = 0; i < S.Length; i++)
        {
            if(S[i] == 'W')
            {
                Wcount++;
            }
            else if(S[i] == 'A')
            {
                if(Wcount > 0)
                {
                    ans += "A";
                    for(int j = 0; j < Wcount; j++)
                    {
                        ans += "C";
                    }
                }
                else
                {
                    ans += "A";
                }
                Wcount = 0;
            }
            else
            {
                ans += S[i];
                Wcount = 0;
            }
            Console.WriteLine(ans);
        }

        for(int i = 0; i < Wcount; i++)
        {
            ans += "W";
        }
        Console.WriteLine(ans);
    }
}

