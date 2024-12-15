
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 入力を受け取る
        string[] nm = Console.ReadLine().Split();
        long n = long.Parse(nm[0]); // N
        int m = int.Parse(nm[1]);  // M

        List<(long, long)> enemyAttack = new List<(long, long)>();

        for(int i = 0; i < m; i++)
        {
            string[] readline = Console.ReadLine().Split();
            long a = int.Parse(readline[0]) - 1;
            long b = int.Parse(readline[1]) - 1;

            enemyAttack.Add((a, b));
            
            //左上方向への攻撃
            if(a - 1 >= 0 && b - 2 >= 0)
            {
                enemyAttack.Add((a - 1, b - 2));
            }
            if(a - 2 >= 0 && b - 1 >= 0)
            {
                enemyAttack.Add((a - 2, b - 1));
            }

            // 右上方向への攻撃
            if(a - 2 >= 0 && b + 1 < n)
            {
                enemyAttack.Add((a - 2, b + 1));
            }
            if(a - 1 >= 0 && b + 2 < n)
            {
                enemyAttack.Add((a - 1, b + 2));
            }

            // 右下方向への攻撃
            if(a + 1 < n && b + 2 < n)
            {
                enemyAttack.Add((a + 1, b + 2));
            }
            if(a + 2 < n && b + 1 < n)
            {
                enemyAttack.Add((a + 2, b + 1));
            }

            // 左下方向への攻撃
            if(a + 2 < n && b - 1 >= 0)
            {
                enemyAttack.Add((a + 2, b - 1));
            }
            if(a + 1 < n && b - 2 >= 0)
            {
                enemyAttack.Add((a + 1, b - 2));
            }
        }
        List<(long, long)> result = new List<(long, long)>();
        result = enemyAttack.Distinct().ToList();
        Console.Write(n * n - result.Count);
    }
}