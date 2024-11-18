using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lines = Console.ReadLine();
        int numberSequenceLength = int.Parse(lines);

        lines = Console.ReadLine();
        for(int i = 0; i < numberSequenceLength; i++)
        {
            var lines = Console.ReadLine();
            string[] inputs = lines.Split(' ');
            quotient[i] =  int.Parse(inputs[0]);
            remainder[i] = int.Parse(inputs[1]);
        }

        var Question_Pat = Console.ReadLine();
        arraySize = int.Parse(Question_Pat);

        int Gabage_Type = 0;
        int Gabage_Day = 0;

        for(int i = 0; i < arraySize; i++)
        {
            var lines = Console.ReadLine();
            string[] inputs = lines.Split(' ');
            Gabage_Type =  int.Parse(inputs[0]);
            Gabage_Day = int.Parse(inputs[1]);

            int Diff = (Gabage_Day % quotient[Gabage_Type - 1]) - remainder[Gabage_Type - 1];
            if(Diff > 0)
            {
                Console.WriteLine(Gabage_Day - Diff + quotient[Gabage_Type - 1]);
            }
            else
            {
                Console.WriteLine(Gabage_Day - Diff);
            }

        }
    }
}
