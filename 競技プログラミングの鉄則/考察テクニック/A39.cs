using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 標準入力の読み込み
        int N = int.Parse(Console.ReadLine());
        var movies = new (int Start, int End)[N];

        for (int i = 0; i < N; i++)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            movies[i] = (input[0], input[1]);
        }

        // 映画を終了時刻で昇順に、開始時刻を降順にソート
        var sortedMovies = movies
            .OrderBy(movie => movie.End)             // 終了時刻で昇順
            .ThenByDescending(movie => movie.Start)  // 開始時刻で降順
            .ToArray();

        int count = 0; // 見た映画の本数
        int currentEndTime = 0; // 現在の終了時刻

        // 貪欲法で映画を選ぶ
        foreach (var movie in sortedMovies)
        {
            if (movie.Start >= currentEndTime) // 現在の終了時刻以降に始まる映画なら選択
            {
                count++;
                currentEndTime = movie.End; // 現在の終了時刻を更新
            }
        }

        // 結果を出力
        Console.WriteLine(count);
    }
}
