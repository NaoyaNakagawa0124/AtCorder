using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    // BIT (Fenwick Tree): 1-indexed, 点更新 + 区間和
    class BIT
    {
        readonly int n;
        readonly long[] tree;
        public BIT(int n) { this.n = n; tree = new long[n + 1]; }
        public void Add(int i, long v)
        {
            for (; i <= n; i += i & -i) tree[i] += v;
        }
        // [1..i] の和
        public long Sum(int i)
        {
            long s = 0;
            for (; i > 0; i -= i & -i) s += tree[i];
            return s;
        }
        // [l..r] の和
        public long Sum(int l, int r)
        {
            if (l > r) return 0;
            return Sum(r) - Sum(l - 1);
        }
    }

    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        var sb = new StringBuilder();

        var firstLine = sr.ReadLine().Split();
        int N = int.Parse(firstLine[0]);
        int Q = int.Parse(firstLine[1]);

        // cnt[x] : マス x の累計 +1 回数 (1-indexed)
        int[] cnt = new int[N + 1];

        // sd : cnt 値 → その値を持つマスの個数 (multiset の代用)
        //   最小キーを見ることで「cnt の最小値」を O(log N) で取得
        var sd = new SortedDictionary<int, int>();
        sd[0] = N; // 初期は cnt[x] = 0 が N 個

        // offset : 一斉削減の累計回数 (本当の高さ = cnt[x] - offset)
        long offset = 0;

        // BIT : インデックス v に「cnt[x] = v となっているマスの個数」を載せる
        //   クエリ2 で「cnt[x] >= y + offset となるマス数」を答える
        //   cnt[x] の取りうる最大値は Q + offset 程度なので、サイズは余裕を持たせる
        int BIT_SIZE = 600005; // 3*10^5 * 2 程度
        var bit = new BIT(BIT_SIZE);
        // 1-indexed にするため、cnt 値 v は BIT の (v+1) 番目に対応させる
        // 初期: cnt=0 のマスが N 個 → bit.Add(0+1, N)
        bit.Add(1, N);

        for (int q = 0; q < Q; q++)
        {
            var line = sr.ReadLine().Split();
            int type = int.Parse(line[0]);

            if (type == 1)
            {
                int x = int.Parse(line[1]);

                int oldv = cnt[x];
                int newv = oldv + 1;
                cnt[x] = newv;

                // sd の更新
                sd[oldv]--;
                if (sd[oldv] == 0) sd.Remove(oldv);
                if (!sd.ContainsKey(newv)) sd[newv] = 0;
                sd[newv]++;

                // BIT の更新
                bit.Add(oldv + 1, -1);
                bit.Add(newv + 1, +1);

                // 一斉削減判定: 本当の最小値 >= 1 か?
                //   本当の最小値 = (sd の最小キー) - offset
                int minK = 0;
                foreach (var k in sd.Keys) { minK = k; break; }
                if (minK - offset >= 1)
                {
                    offset++;
                }
            }
            else
            {
                int y = int.Parse(line[1]);

                // 高さ >= y のマス数
                //   = cnt[x] - offset >= y のマス数
                //   = cnt[x] >= y + offset のマス数
                //   = BIT の [y+offset+1 .. BIT_SIZE] の総和  (cnt値 v は BIT の v+1)
                long threshold = (long)y + offset; // 必要な最小 cnt 値
                long lo = threshold + 1;           // BIT 上の左端 (1-indexed)
                long ans;
                if (lo > BIT_SIZE) ans = 0;
                else ans = bit.Sum((int)lo, BIT_SIZE);

                sb.AppendLine(ans.ToString());
            }
        }

        Console.Write(sb.ToString());
    }
}
