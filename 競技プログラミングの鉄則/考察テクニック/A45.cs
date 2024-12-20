using System;

class Program
{
    static char Combine(char x, char y)
    {
        // 与えられたルールに従って2枚を合成
        if (x == y)
        {
            // 同色合成
            // R+R=B, B+B=R, W+W=W
            if (x == 'R') return 'B';
            if (x == 'B') return 'R';
            return 'W'; // x==W
        }
        else
        {
            // 異色合成
            // R+B=W, B+R=W
            // W+B=B, B+W=B
            // W+R=R, R+W=R
            // 順不同で同じ結果になるので、順序を合わせて判定
            if ((x == 'R' && y == 'B') || (x == 'B' && y == 'R'))
                return 'W';
            if ((x == 'W' && y == 'B') || (x == 'B' && y == 'W'))
                return 'B';
            // (x == 'W' && y == 'R') || (x == 'R' && y == 'W')
            return 'R';
        }
    }

    static void Main()
    {
        var line = Console.ReadLine().Split();
        int N = int.Parse(line[0]);
        char C = line[1][0];

        string A = Console.ReadLine().Trim();

        char result = A[0];
        for (int i = 1; i < N; i++)
        {
            result = Combine(result, A[i]);
        }

        Console.WriteLine(result == C ? "Yes" : "No");
    }
}
