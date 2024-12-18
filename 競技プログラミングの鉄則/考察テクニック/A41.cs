using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string tileCondition = Console.ReadLine();
        int counter = 1;
        char tmpColor = tileCondition[0];
        for (int i = 1; i < N; i++)
        {
            if(tileCondition[i] == tmpColor)
            {
                counter++;
            }
            else
            {
                if(tmpColor == 'R')
                {
                    tmpColor = 'B';
                }
                else
                {
                    tmpColor = 'R';
                }
                counter = 1;
            }

            if(counter == 3)
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");
    }
}
