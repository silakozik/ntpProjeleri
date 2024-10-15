using System;
using System.Collections.Generic;

class TempleMaze
{
    static int N;  // NxN labirent boyutu
    static int[,] maze;  // Labirent verisi
    static int[] dx = { -1, 1, 0, 0 }; // Yukarı, Aşağı, Sağ, Sol
    static int[] dy = { 0, 0, 1, -1 };

    static void Main(string[] args)
    {
        // NxN labirent boyutunu al
        Console.WriteLine("N boyutunu giriniz (NxN labirent):");
        N = int.Parse(Console.ReadLine());

        maze = new int[N, N];

        // Labirent verisini al
        Console.WriteLine("Labirenti girin (1: Yürünebilir yol, 0: Tuzak/Duvar):");
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int j = 0; j < N; j++)
            {
                maze[i, j] = int.Parse(input[j]);
            }
        }

        // En kısa yolu hesapla
        int result = ShortestPath();
        if (result == -1)
        {
            Console.WriteLine("Yol Yok");
        }
        else
        {
            Console.WriteLine($"En Kısa Yol: {result} adım");
        }

        // Çıkış öncesi beklet
        Console.WriteLine("\nÇıkmak için Enter'a basın.");
        Console.ReadLine();
    }

    static int ShortestPath()
    {
        // BFS için kuyruk ve ziyaret edilen dizisi
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        bool[,] visited = new bool[N, N];

        // Başlangıç noktasını ekle (x, y, adım sayısı)
        queue.Enqueue(new Tuple<int, int, int>(0, 0, 0));
        visited[0, 0] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;
            int steps = current.Item3;

            // Hazineye ulaşıldı mı?
            if (x == N - 1 && y == N - 1)
            {
                return steps; // En kısa yolun adım sayısını döndür
            }

            // Komşu hücreleri kontrol et
            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                // Geçerli hücre mi?
                if (nx >= 0 && nx < N && ny >= 0 && ny < N && maze[nx, ny] == 1 && !visited[nx, ny])
                {
                    queue.Enqueue(new Tuple<int, int, int>(nx, ny, steps + 1));
                    visited[nx, ny] = true; // Ziyaret edildi olarak işaretle
                }
            }
        }

        return -1; // Hazineye ulaşmak mümkün değil
    }
}

