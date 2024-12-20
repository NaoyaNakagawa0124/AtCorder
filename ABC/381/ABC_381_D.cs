using System;
using System.Collections.Generic;
class Program
{
    static int Main()
    {
        // 文字数を読み取る
        int string_length = int.Parse(Console.ReadLine());

        int counter = 0;
        int ans = 0;
        int j = 0;
        bool flag = true;

        // 任意の文字列
        string[] target_string = Console.ReadLine().Split();
        int[] A = new int[string_length];
        for(int i = 0; i < string_length; i++)
        {
            A[i] = int.Parse(target_string[i]);
        }

        for(int i = 0 ; i < string_length - 1; i++)
        {
            if(A[i] == A[i + 1])
            {
                //見ているインデックスの数が一緒だった時
                counter += 2;
                j = i + 2;

                // リストに数字を格納する(このリスト内の数字と一致したらそれは1122数列ではなくなる)
                List<int> Duplicate = new List<int>();
                Duplicate.Add(A[i]);

                // そこを起点にどこまで1122数列が続くかを探索
                while(flag)
                {
                    if(j + 1 > string_length - 1)
                    {
                        ans = Math.Max(ans, counter);
                        Console.WriteLine(ans);
                        return 0;
                    }
                    else
                    {
                        if(A[j] == A[j + 1])
                        {
                            foreach(int num in Duplicate)
                            {
                                if(num == A[j])
                                {
                                    flag = false;
                                }
                            }
                            if(flag)
                            {
                                counter += 2;
                                Duplicate.Add(A[j]);
                                j += 2;
                            }
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }
            ans = Math.Max(ans, counter);
            if(ans > string_length / 2 || ans > (string_length - i) * 2)
            {
                Console.WriteLine(ans);
                return 0;
            }
            flag = true;
            counter = 0;
        }
        Console.WriteLine(ans);
        return 0;
    }
}