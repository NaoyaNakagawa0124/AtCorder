using System;
using System.Collections.Generic;

class Food
{
    public int Type;   
    public long Amount; 
    public int Cal;     
}

class Program
{
    static void Main()
    {
        string[] xy = Console.ReadLine().Split();
        int N = int.Parse(xy[0]);
        int X = int.Parse(xy[1]);

        List<Food> allFoods = new List<Food>();
        for (int i = 0; i < N; i++)
        {
            string[] t = Console.ReadLine().Split();
            int v = int.Parse(t[0]);
            long a = long.Parse(t[1]);
            int c = int.Parse(t[2]);
            allFoods.Add(new Food { Type = v, Amount = a, Cal = c });
        }

        List<Food> list1 = new List<Food>();
        List<Food> list2 = new List<Food>();
        List<Food> list3 = new List<Food>();

        for (int i = 0; i < N; i++)
        {
            if (allFoods[i].Type == 1) list1.Add(allFoods[i]);
            else if (allFoods[i].Type == 2) list2.Add(allFoods[i]);
            else list3.Add(allFoods[i]);
        }

        long[] dp1 = new long[X + 1];
        long[] dp2 = new long[X + 1];
        long[] dp3 = new long[X + 1];

        for (int i = 0; i < list1.Count; i++)
        {
            long a = list1[i].Amount;
            int c = list1[i].Cal;
            for (int cost = X; cost >= c; cost--)
            {
                long tmp = dp1[cost - c] + a;
                if (tmp > dp1[cost]) dp1[cost] = tmp;
            }
        }

        for (int i = 0; i < list2.Count; i++)
        {
            long a = list2[i].Amount;
            int c = list2[i].Cal;
            for (int cost = X; cost >= c; cost--)
            {
                long tmp = dp2[cost - c] + a;
                if (tmp > dp2[cost]) dp2[cost] = tmp;
            }
        }

        for (int i = 0; i < list3.Count; i++)
        {
            long a = list3[i].Amount;
            int c = list3[i].Cal;
            for (int cost = X; cost >= c; cost--)
            {
                long tmp = dp3[cost - c] + a;
                if (tmp > dp3[cost]) dp3[cost] = tmp;
            }
        }

        long ans = 0;
        for (int c1 = 0; c1 <= X; c1++)
        {
            for (int c2 = 0; c2 <= X - c1; c2++)
            {
                int c3 = X - (c1 + c2);
                long v1 = dp1[c1];
                long v2 = dp2[c2];
                long v3 = dp3[c3];
                long m = v1 < v2 ? v1 : v2;
                if (v3 < m) m = v3;
                if (m > ans) ans = m;
            }
        }

        Console.WriteLine(ans);
    }
}
