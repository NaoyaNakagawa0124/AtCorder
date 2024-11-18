using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 最も基本的な標準入力の読み込み
        string readLine = Console.ReadLine();
        int decimalValue = int.Parse(readLine);

        int[] binaryPowers = new int[]{1, 2, 4, 8, 16, 32, 64, 128, 256, 512};
        for(int i = binaryPowers.Length - 1; i >= 0; i--)
        {
            if(decimalValue - binaryPowers[i] >= 0)
            {
                Console.Write("1");
                decimalValue = decimalValue - binaryPowers[i];
            }
            else
            {
                Console.Write("0");
            }
        }
    }
}
