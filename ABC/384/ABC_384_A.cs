using System;
class Program
{
    static int Main()
    {

        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);

        char c1 = readline[1][0];
        char c2 = readline[2][0];

        char[] target_string = Console.ReadLine().ToCharArray();

        for (int i = 0; i < N; i++)
        {
            if(target_string[i] != c1)
            {
                target_string[i] = c2;
            }
            Console.Write(target_string[i]);
        }
        return 0;
    }
}