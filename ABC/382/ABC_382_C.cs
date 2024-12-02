using System;
using System.Collections.Generic;

class Program
{
    static int Main()
    {

        // 問題文での人の最大の数値
        int maxCustomrs = 200001;
        // 文字数を読み取る
        string[] readline = Console.ReadLine().Split();
        int BisyokuLength = int.Parse(readline[0]);
        int SushiLength = int.Parse(readline[1]); 

        string[] bisyokuArray_string = Console.ReadLine().Split();
        int[] bisyokuArray = new int [BisyokuLength];
        for(int i = 0; i < BisyokuLength; i++)
        {
            bisyokuArray[i] = int.Parse(bisyokuArray_string[i]);
        }

        int[] eatersForSushiN = new int[maxCustomrs];

        for(int i = 0; i < eatersForSushiN.Length; i++)
        {
            eatersForSushiN[i] = -1;
        }

        int counter = maxCustomrs - 1;
        
        for(int i = 0; i < BisyokuLength; i++)
        {
            while(counter >= bisyokuArray[i])
            {
                eatersForSushiN[counter] = i + 1;
                counter--;
            }
        }

        string[] sushiArray_string = Console.ReadLine().Split();
        int[] sushiArray = new int [SushiLength];
        for(int i = 0; i < SushiLength; i++)
        {
            sushiArray[i] = int.Parse(sushiArray_string[i]);
            Console.WriteLine(eatersForSushiN[sushiArray[i]]);
        }
        return 0;
    }
}


//こっちは復習前の実際に取り組んだ時のソースコード
// ランタイムエラーが出ている
// using System;
// using System.Collections.Generic;

// class Program
// {
//     static int Main()
//     {
//         文字数を読み取る
//         string[] readline = Console.ReadLine().Split();
//         int BisyokuLength = int.Parse(readline[0]);
//         int SushiLength = int.Parse(readline[1]); 

//         string[] bisyokuArray_string = Console.ReadLine().Split();
//         int[] bisyokuArray = new int [BisyokuLength];
//         bisyokuArray[0] = int.Parse(bisyokuArray_string[0]);
        
//         List<int> searchList1 = new List<int>();
//         List<int> searchList2 = new List<int>();

//         searchList1.Add(1);
//         searchList2.Add(bisyokuArray[0]);
        
//         for(int i = 1; i < BisyokuLength; i++)
//         {
//             bisyokuArray[i] = int.Parse(bisyokuArray_string[i]);
            
//             if(bisyokuArray[i -1] <= bisyokuArray[i])
//             {
//                 bisyokuArray[i] = bisyokuArray[i - 1];
//             }
//             else
//             {
//                 searchList1.Add(i + 1);
//                 searchList2.Add(bisyokuArray[i]);   
//             }
//         }

//         string[] sushiArray_string = Console.ReadLine().Split();
//         int[] sushiArray = new int [SushiLength];
//         for(int i = 0; i < SushiLength; i++)
//         {
//             sushiArray[i] = int.Parse(sushiArray_string[i]);
//         }

//         int counter = 0;

//         for(int i = 0; i < SushiLength; i++)
//         {
//             counter = 0;
//             for(int j = 0; j < searchList1.Count; j++)
//             {
//                 if(searchList2[j] <= sushiArray[i])
//                 {
//                     Console.WriteLine(searchList1[j]);
//                     counter++;
//                     break;
//                 }
//             }
//             if(counter == 0)
//             {
//                 Console.WriteLine(-1);
//             }
//         }
//         return 0;
//     }
// }