using System;
using System.Collections.Generic;

class TechCityRescue
{
    static int N;  // NxN grid boyutu
    static int[,] grid;  // Grid verisi
    static bool[,] visited;  // Ziyaret edilen düğümler

    // Yönleri belirle: yukarı, aşağı, sağ, sol
    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, 1, -1 };

    // Robotların müdahale edeceği düğümleri kurtarma
    static int Rescue(int x, int y)
    {
        // Eğer düğüm kurtarılabilir değilse veya ziyaret edildiyse dur.
        if (x < 0 || x >= N || y < 0 || y >= N || grid[x, y] == 0 || visited[x, y])
        {
            return 0;
        }

        visited[x, y] = true;  // Düğüm ziyaret edildi
        int count = 1;  // Kurtarılan düğüm sayısını başlat

        // 4 yöne git ve komşu düğümleri kontrol et
        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            count += Rescue(nx, ny);  // Komşu düğüm kurtarıldı mı kontrol et
        }

        return count;
    }

    static void Main(string[] args)
    {
        // NxN grid boyutunu al
        Console.WriteLine("N boyutunu giriniz (NxN grid):");
        N = int.Parse(Console.ReadLine());

        grid = new int[N, N];
        visited = new bool[N, N];

        // Grid verisini al
        Console.WriteLine("Grid'i girin (1: Kurtarılabilir düğüm, 0: Zarar görmüş düğüm):");
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int j = 0; j < N; j++)
            {
                grid[i, j] = int.Parse(input[j]);
            }
        }

        // Robotların başlangıç noktalarını belirle
        Console.WriteLine("3 robotun başlangıç noktalarını girin (örneğin: 0 0, 1 2, 3 3):");
        List<Tuple<int, int>> robots = new List<Tuple<int, int>>();

        for (int i = 0; i < 3; i++) // 3 robot için döngü
        {
            Console.WriteLine($"Robot {i + 1} için x ve y koordinatlarını girin (örneğin: x y):");
            string[] coordinates = Console.ReadLine().Split(' ');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);
            robots.Add(new Tuple<int, int>(x, y));
        }

        // Kurtarılan düğüm sayısını hesapla
        int totalRescued = 0;
        foreach (var robot in robots)
        {
            totalRescued += Rescue(robot.Item1, robot.Item2);
        }

        // Sonucu yazdır
        Console.WriteLine($"Toplam kurtarılan düğüm sayısı: {totalRescued}");

        // Grid'i ve ziyaret edilen düğümleri yazdır
        Console.WriteLine("\nZiyaret edilen düğümler:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (visited[i, j])
                {
                    Console.Write("R ");  // Kurtarılan düğüm
                }
                else
                {
                    Console.Write(grid[i, j] == 1 ? "1 " : "0 ");  // Kurtarılmamış düğüm
                }
            }
            Console.WriteLine();
        }

        // Çıkış öncesi beklet
        Console.WriteLine("\nÇıkmak için Enter'a basın.");
        Console.ReadLine();
    }
}
