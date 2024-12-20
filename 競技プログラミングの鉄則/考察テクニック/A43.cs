using System;

class Program
{
    static void Main()
    {
        int ans = 0;
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int L = int.Parse(readline[1]);
        

        for (int i = 1; i <= N; i++)
        {
            int tmpAns = 0;
            readline = Console.ReadLine().Split();
            int x = int.Parse(readline[0]);
            if(readline[1] == "E")
            {
                tmpAns = L - x;
            }
            else
            {
                tmpAns = x;
            }
            ans = Math.Max(ans, tmpAns);
        }
        Console.WriteLine(ans);
    }
}

