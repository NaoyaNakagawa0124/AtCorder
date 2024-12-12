using System;
class Program
{
    static int Main()
    {
        char[, ] floor_condition = new char[8 ,8];
        for(int i = 0; i < 8; i++)
        {
            string readline = Console.ReadLine();
            for(int j = 0; j < 8; j++)
            {
                floor_condition[i , j] = readline[j];
            }
        }
        
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if(floor_condition[i, j] == '#')
                {
                    for(int k = 0; k < 8; k++)
                    {
                        if(floor_condition[i ,k] != '#')
                        {
                            floor_condition[i, k] = 'z';
                        }
                        if(floor_condition[k, j] != '#')
                        {
                            floor_condition[k, j] = 'z'; 
                        }
                    }
                }
            }
        }
        int counter = 0;
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if(floor_condition[i, j] == '.')
                {
                    counter++;
                }
            }
        }
        Console.WriteLine(counter);   
        return 0;
    }
}