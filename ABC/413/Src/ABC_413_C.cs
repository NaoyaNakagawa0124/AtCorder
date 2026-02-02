using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        int Q = int.Parse(line);
        string[] arr;
        List<KeyValuePair<int, int>> pairs = new List<KeyValuePair<int, int>>();

        for (int i = 0; i < Q; i++)
        {
            arr = Console.ReadLine().Split();
            if (int.Parse(arr[0]) == 1)
            {
                int c = int.Parse(arr[1]);
                int x = int.Parse(arr[2]);
                pairs.Add(new KeyValuePair<int, int>(c, x));
            }
            else if (int.Parse(arr[0]) == 2)
            {
                int k = int.Parse(arr[1]);
                int out_number = 0;
                long ans = 0;
                while (out_number != k)
                {
                    KeyValuePair<int, int> pair = pairs[0];
                    if (out_number + pair.Key <= k)
                    {
                        ans += pair.Value * pair.Key;
                        out_number += pair.Key;
                        pairs.RemoveAt(0);
                    }
                    else
                    {
                        ans += pair.Value * (k - out_number);
                        pairs[0] = new KeyValuePair<int, int>(pairs[0].Key - k + out_number, pairs[0].Value);
                        out_number = k;
                    }
                }
                Console.WriteLine(ans);
            }
            else
            {
                Console.WriteLine("error");
            }
            // Console.WriteLine($"{i}回目のpairsの様子は");
            // foreach (KeyValuePair<int, int> pair in pairs)
            // {
            //     Console.WriteLine($"pair.Key = {pair.Key}, pair.Value = {pair.Value}");
            // }
        }

    }
}

