using System;

class SpiralMatrix
{
    public static void Main(string[] args)
    {
        // Kullanıcıdan NxN matris boyutunu al
        Console.WriteLine("NxN boyutunu giriniz:");
        int n = int.Parse(Console.ReadLine()); // Kullanıcı girişi

        // NxN boyutunda bir matris oluştur
        int[,] matrix = new int[n, n];

        // Spiral matris için başlangıç değeri
        int value = 1;

        // Matrisin sınırlarını tutacak değişkenler
        int startRow = 0, endRow = n - 1;
        int startCol = 0, endCol = n - 1;

        // Spiral şekilde matris doldurma döngüsü
        while (startRow <= endRow && startCol <= endCol)
        {
            // Üst sırayı soldan sağa doğru doldur
            for (int i = startCol; i <= endCol; i++)
            {
                matrix[startRow, i] = value++; // Sıradaki değeri matrise ekle
            }
            startRow++; // Bir alt sıraya geç

            // Sağ sütunu yukarıdan aşağıya doğru doldur
            for (int i = startRow; i <= endRow; i++)
            {
                matrix[i, endCol] = value++; // Sıradaki değeri matrise ekle
            }
            endCol--; // Sağ sınırı bir sola çek

            // Alt sırayı sağdan sola doğru doldur
            if (startRow <= endRow)
            {
                for (int i = endCol; i >= startCol; i--)
                {
                    matrix[endRow, i] = value++; // Sıradaki değeri matrise ekle
                }
                endRow--; // Alt sınırı bir yukarı çek
            }

            // Sol sütunu aşağıdan yukarıya doğru doldur
            if (startCol <= endCol)
            {
                for (int i = endRow; i >= startRow; i--)
                {
                    matrix[i, startCol] = value++; // Sıradaki değeri matrise ekle
                }
                startCol++; // Sol sınırı bir sağa çek
            }
        }

        // Spiral matrisi ekrana yazdır
        Console.WriteLine("Spiral Matris:");
        for (int i = 0; i < n; i++) // Satır döngüsü
        {
            for (int j = 0; j < n; j++) // Sütun döngüsü
            {
                Console.Write(matrix[i, j] + "\t"); // Matristeki elemanı yazdır
            }
            Console.WriteLine(); // Satır sonuna gelince alt satıra geç
        }

        // Programın hemen kapanmasını önle
        Console.WriteLine("\nÇıkmak için Enter'a basın.");
        Console.ReadLine(); // Kullanıcıdan girdi bekle
    }
}
