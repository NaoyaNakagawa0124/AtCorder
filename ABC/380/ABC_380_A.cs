using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        char[] target_string = Console.ReadLine().ToCharArray();

        // int型に変更
        int[] numArray = new int[target_string.Length];
        for (int i = 0; i < target_string.Length; i++)
        {
            numArray[i] = int.Parse(target_string[i].ToString());
        }

        int times = 1;
        int counter = 0;

        while(times < 4)
        {
            counter = 0;
            for(int i = 0; i < numArray.Length; i++)
            {
                if(numArray[i] == times)
                {
                    counter++;
                }
            }
            if(counter != times)
            {
                Console.Write("No");
                return 0;
            }
            times++;
        }
        Console.WriteLine("Yes");
        return 0;
    }
}