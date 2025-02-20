using System;

class Program
{
    static void Main()
    {
        string[] str = Console.ReadLine().Split();
        int[] arr = Array.ConvertAll(str, int.Parse);

        bool alreadySorted = true;
        for (int i = 0; i < 5; i++)
        {
            if (arr[i] != i + 1)
            {
                alreadySorted = false;
                break;
            }
        }
        if (alreadySorted)
        {
            Console.WriteLine("No");
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            int[] temp = (int[])arr.Clone();
            int t = temp[i];
            temp[i] = temp[i + 1];
            temp[i + 1] = t;

            bool sorted = true;
            for (int j = 0; j < 5; j++)
            {
                if (temp[j] != j + 1)
                {
                    sorted = false;
                    break;
                }
            }
            if (sorted)
            {
                Console.WriteLine("Yes");
                return;
            }
        }

        Console.WriteLine("No");
    }
}
