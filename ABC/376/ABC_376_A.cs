using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string[] nc = Console.ReadLine().Split();
        int N = int.Parse(nc[0]);
        int C = int.Parse(nc[1]);

        string[] target_string = Console.ReadLine().Split();
        int[] time = new int[N];
        for(int i = 0; i < N; i++)
        {
            time[i] = int.Parse(target_string[i]);
        }
        int preTime = time[0];
        int counter = 1;
        for(int i = 1; i < N; i++)
        {
            if(time[i] - preTime >= C)
            {
                counter++;
                preTime = time[i];
            }
        }
        Console.WriteLine(counter);
        return 0;
    }
}