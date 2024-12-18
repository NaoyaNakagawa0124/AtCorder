using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        int M = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        int counter = 3;
        int tmpNumber = 1;

        while(M != 0)
        {
            tmpNumber = 3;
            counter = 1;
            while(M > 3 * tmpNumber)
            {
                tmpNumber *= 3;
                counter++;
            }
            if(M == 1)
            {
                numbers.Add(0);
                M -= 1;
            }
            else if(M == 2)
            {
                numbers.Add(0);
                numbers.Add(0);
                M -= 2;
            }
            else
            {
                numbers.Add(counter);
                M -= tmpNumber;
            }
        }

        Console.WriteLine(numbers.Count);
        
        for(int i = 0; i < numbers.Count; i++)
        {
            Console.Write(numbers[i]);
            if(i != numbers.Count - 1)
            {
                Console.Write(" ");
            }
        }
        return 0;
    }
}