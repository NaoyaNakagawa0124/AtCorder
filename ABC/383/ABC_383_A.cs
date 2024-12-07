using System;
class Program
{
    static int Main()
    {

        int N = int.Parse(Console.ReadLine());
        int[] T = new int[N];
        int[] V = new int[N];

        int tmpLittle = 0;

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            T[i] = int.Parse(input[0]); 
            V[i] = int.Parse(input[1]);
        }

        tmpLittle = V[0];

       for(int i = 1; i < N; i++)
       {
            if(tmpLittle - (T[i] -  T[i - 1])  > 0)
            {
                tmpLittle = tmpLittle - (T[i] -  T[i - 1]) + V[i];
            }
            else
            {
                tmpLittle = V[i];
            }
       }
        Console.WriteLine(tmpLittle);
        return 0;
    }
}