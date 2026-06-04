using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        var reader = new StreamReader(Console.OpenStandardInput());
        var sb = new StringBuilder();

        long X = long.Parse(reader.ReadLine());
        int Q = int.Parse(reader.ReadLine());

        var low = new PriorityQueue<long, long>();
        var high = new PriorityQueue<long, long>();

        Add(low, high, X);

        for (int i = 0; i < Q; i++)
        {
            var line = reader.ReadLine().Split();
            long A = long.Parse(line[0]);
            long B = long.Parse(line[1]);
            Add(low, high, A);
            Add(low, high, B);
            sb.AppendLine(low.Peek().ToString());
        }

        Console.Write(sb.ToString());
    }

    static void Add(PriorityQueue<long, long> low, PriorityQueue<long, long> high, long v)
    {
        if (low.Count == 0 || v <= low.Peek()) low.Enqueue(v, -v);
        else high.Enqueue(v, v);

        if (low.Count > high.Count + 1)
        {
            long x = low.Dequeue();
            high.Enqueue(x, x);
        }
        else if (low.Count < high.Count)
        {
            long x = high.Dequeue();
            low.Enqueue(x, -x);
        }
    }
}
