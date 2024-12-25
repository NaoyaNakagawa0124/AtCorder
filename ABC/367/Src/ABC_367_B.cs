using System;
class Program
{
    static int Main()
    {
        string readline = Console.ReadLine();
        int Count = readline.Length;
        for(int i = readline.Length - 1; i >= 0; i--)
        {
            if(readline[i] == '0')
            {
                Count--;
            }
            else if(readline[i] == '.')
            {
                if(Count == readline.Length)
                {
                    Count = readline.Length;
                    break;
                }
                else
                {
                    Count--;
                    break;
                }
            }
            else
            {
                break;
            }
        }
        for(int i = 0; i < Count; i++)
        {
            Console.Write(readline[i]);
        }
        return 0;
    }
}
