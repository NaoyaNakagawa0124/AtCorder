using System;
class Program
{
    static int Main()
    {
        // 文字列の読み込み
        string readLine = Console.ReadLine();
        int N = int.Parse(readLine);

        double counter = 0;

        int tmpX = 0;
        int tmpY = 0;

        int x = 0;
        int y = 0;

        double disX = 0;
        double disY = 0;

        for(int i = 0; i < N; i++)
        {
            string[] target_string = Console.ReadLine().Split();
            x = int.Parse(target_string[0]);
            y = int.Parse(target_string[1]);
            disX = Math.Abs(x - tmpX);
            disY = Math.Abs(y - tmpY);
            counter += Math.Sqrt(disX * disX + disY * disY);
            tmpX = x;
            tmpY = y;
        }

        x = 0;
        y = 0;
        disX = Math.Abs(x - tmpX);
        disY = Math.Abs(y - tmpY);
        counter += Math.Sqrt(disX * disX + disY * disY);

        Console.WriteLine(counter);
        return 0;
    }
}