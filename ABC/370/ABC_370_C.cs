using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        char[] S = Console.ReadLine().ToCharArray();
        char[] T= Console.ReadLine().ToCharArray();

        List<string> ans = new List<string>();


        for(int i = 0; i < S.Length; i++)
        {
            if(S[i].CompareTo(T[i]) > 0)
            {
                S[i] = T[i];
                string tmp = "";
                for(int j = 0; j < S.Length; j++)
                {
                    tmp += S[j].ToString();
                }
                ans.Add(tmp);
            }
        }

        for(int i = S.Length - 1; i >= 0; i--)
        {
            if(S[i].CompareTo(T[i]) < 0)
            {
                S[i] = T[i];
                string tmp = "";
                for(int j = 0; j < S.Length; j++)
                {
                    tmp += S[j].ToString();
                }
                ans.Add(tmp);
            }
        }
        Console.WriteLine(ans.Count);
        foreach(var item in ans)
        {
            Console.WriteLine(item);
        }
    }
}