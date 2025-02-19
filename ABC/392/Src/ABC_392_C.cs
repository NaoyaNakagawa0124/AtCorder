// using System;
// using System.Collections.Generic;

// class Program
// {
//     static int Main()
//     {
//         int N = int.Parse(Console.ReadLine());

//         int[] P = new int[N];
//         string[] readline = Console.ReadLine().Split();
//         for(int i = 0; i < N; i++)
//         {
//             P[i] = int.Parse(readline[i]);
//         }

//         int[] Q = new int[N];
//         readline = Console.ReadLine().Split();
//         for(int i = 0; i < N; i++)
//         {
//             Q[i] = int.Parse(readline[i]);
//         }

//         // i番目のゼッケンを着けている人がみている人
//         SortedList<int, int> bibHolder = new SortedList<int, int>();
//         for(int i = 0; i < N; i++)
//         {
//             bibHolder.Add(Q[i], P[i]);
//         }

//         // foreach (var item in bibHolder)
//         // {
//         //     Console.WriteLine($"{item.Key} {item.Value}");
//         // }
//         // Console.WriteLine();

//         foreach (var item in bibHolder)
//         {
//             Console.Write($"{Q[item.Value - 1]} ");
//         }

//         return 0;
//     }
// }


using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] P = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] Q = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // Q[i] をキー、P[i] を値として格納する
        SortedDictionary<int, int> bibHolder = new SortedDictionary<int, int>();
        for (int i = 0; i < N; i++)
        {
            bibHolder.Add(Q[i], P[i]);
        }

        // ソート済みのキー順に処理する
        foreach (var item in bibHolder)
        {
            // item.Value は P[i] の値。ここでは Q[item.Value - 1] を出力する
            Console.Write($"{Q[item.Value - 1]} ");
        }
        return 0;
    }
}
