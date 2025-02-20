using System;

class Program
{
    static int Main()
    {
        string S = Console.ReadLine();
        int count = 0;
        int n = S.Length;

        for (int i = 0; i < n - 2; i++)
        {
            if (S[i] == 'A')
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    if (S[j] == 'B')
                    {
                        int k = 2 * j - i; 
                        if (k < n && S[k] == 'C')
                        {
                            count++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(count);
        return 0;
    }
}
