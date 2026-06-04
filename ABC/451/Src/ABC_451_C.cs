using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int Q = int.Parse(Console.ReadLine());
        int num_tree = 0;
        SortedDictionary<long, int> tree_height = new SortedDictionary<long, int>(); //高さがkeyで本数がvalue

        for (int i = 0; i < Q; i++)
        {
            string[] readline = Console.ReadLine().Split();
            int question = int.Parse(readline[0]);
            long height = long.Parse(readline[1]);

            if (question == 1)
            {
                if (tree_height.ContainsKey(height))
                {
                    tree_height[height]++;
                }
                else
                {
                    tree_height.Add(height, 1);
                }
                num_tree++;
                Console.WriteLine(num_tree);
            }
            else
            {
                var keysToRemove = new List<long>();
                foreach (var item in tree_height)
                {
                    if (item.Key > height) break;
                    num_tree -= item.Value;
                    keysToRemove.Add(item.Key);
                }
                foreach (var key in keysToRemove)
                {
                    tree_height.Remove(key);
                }
                Console.WriteLine(num_tree);
            }
        }
    }
}

