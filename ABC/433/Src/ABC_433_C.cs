using System;

class Program
{
    static void Main()
    {
        string S = Console.ReadLine();
        int n = S.Length;
        long count = 0;

        int i = 0;
        while (i < n)
        {
            char d = S[i];
            
            // 位置iから同じ数字dが何文字続くか
            int cnt1 = 0;
            while (i + cnt1 < n && S[i + cnt1] == d)
            {
                cnt1++;
            }
            
            // その次の位置から数字d+1が何文字続くか
            int j = i + cnt1;
            if (j < n && S[j] == d + 1)
            {
                int cnt2 = 0;
                while (j + cnt2 < n && S[j + cnt2] == (char)(d + 1))
                {
                    cnt2++;
                }
                
                // 1122文字列の個数 = min(cnt1, cnt2)
                count += Math.Min(cnt1, cnt2);
            }
            
            // 次の異なる数字の塊へ移動
            i += cnt1;
        }
        
        Console.WriteLine(count);
    }
}