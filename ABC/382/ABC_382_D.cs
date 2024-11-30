using System;
class Program
{
    static int Main()
    {
        // 文字数を読み取る
        string[] readline = Console.ReadLine().Split();
        int targetLength = int.Parse(readline[0]);
        int tagetNumber = int.Parse(readline[1]); 

        int hundredTargetNumber = tagetNumber / 100;
        int tenTargetNumber = tagetNumber / 10;
        int oneTargetNumber = tagetNumber - hundredTargetNumber * 100 - tenTargetNumber * 10;

        if(oneTargetNumber == 0)
        {
            oneTargetNumber = 10;
        }

        int i = 1;

        while(i <= oneTargetNumber)
        {
            for(int j = 1; j < oneTargetNumber; j++)
            {
                for(int k = 1; k < oneTargetNumber; k++)
                {
                    for(int l = 0; l < targetLength; l++)
                    {
                        
                    }
                }
            }
        }
        return 0;
    }
    
}