using System;
class Program
{
    static int Main()
    {
        
        string[] readline = Console.ReadLine().Split();
        int N = int.Parse(readline[0]);
        int K = int.Parse(readline[1]);

        char[] target_string = Console.ReadLine().ToCharArray();

        int counter = 0;
        int maxStrawberry = 0;

        for(int i = 0; i < N; i++)
        {
            if(target_string[i] == 'O')
            {
                counter++;
                if(counter == K)
                {
                    maxStrawberry++;
                    counter = 0;
                }
            }
            else
            {
                counter = 0;
            }
        }
        Console.Write(maxStrawberry);
        return 0;
    }
}