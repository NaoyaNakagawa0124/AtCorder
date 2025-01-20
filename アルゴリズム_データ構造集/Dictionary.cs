using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {
        // 入力の受け取り
        int Q = int.Parse(Console.ReadLine());
        Dictionary<string, int> queries = new Dictionary<string, int>();
        for (int i = 0; i < Q; i++)
        {
            string[] readLine = Console.ReadLine().Split(" ");
            if(int.Parse(readLine[0]) == 1)
            {
                queries.Add(readLine[1], int.Parse(readLine[2]));
            }
            else if(int.Parse(readLine[0]) == 2)
            {
                Console.WriteLine(queries[readLine[1]].ToString());
            }
        }
        return 0;
    }
}
