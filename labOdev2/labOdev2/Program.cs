using System;

class MatrixMultiplication
{
    public static void Main(string[] args)
    {
        // Kullanıcıdan NxN matris boyutunu al
        Console.WriteLine("NxN boyutunu giriniz:");
        int n = int.Parse(Console.ReadLine());  // Kullanıcıdan matris boyutunu oku

        // İki NxN matrisi tanımla
        int[,] matrixA = new int[n, n];  // Birinci matris
        int[,] matrixB = new int[n, n];  // İkinci matris
        int[,] resultMatrix = new int[n, n]; // Çarpım sonucu olacak matris

        // Birinci matrisi (A) kullanıcıdan al
        Console.WriteLine("Birinci matrisin (A) elemanlarını giriniz:");
        for (int i = 0; i < n; i++) // Satır döngüsü
        {
            for (int j = 0; j < n; j++) // Sütun döngüsü
            {
                Console.Write($"A[{i},{j}] = "); // Kullanıcıdan matris elemanını isteme
                matrixA[i, j] = int.Parse(Console.ReadLine()); // Kullanıcı girişi al
            }
        }

        // İkinci matrisi (B) kullanıcıdan al
        Console.WriteLine("İkinci matrisin (B) elemanlarını giriniz:");
        for (int i = 0; i < n; i++) // Satır döngüsü
        {
            for (int j = 0; j < n; j++) // Sütun döngüsü
            {
                Console.Write($"B[{i},{j}] = "); // Kullanıcıdan matris elemanını isteme
                matrixB[i, j] = int.Parse(Console.ReadLine()); // Kullanıcı girişi al
            }
        }

        // İki matrisi çarpıyoruz
        for (int i = 0; i < n; i++) // A matrisinin satır döngüsü
        {
            for (int j = 0; j < n; j++) // B matrisinin sütun döngüsü
            {
                resultMatrix[i, j] = 0; // Sonuç matrisindeki her hücreyi sıfırla
                for (int k = 0; k < n; k++) // İç döngü: A'nın satırı ile B'nin sütunu çarpımı
                {
                    resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j]; // Çarpım ve toplama işlemi
                }
            }
        }

        // Çarpım matrisini ekrana yazdırıyoruz
        Console.WriteLine("İki matrisin çarpımı (sonuç matrisi):");
        for (int i = 0; i < n; i++) // Sonuç matrisinin satır döngüsü
        {
            for (int j = 0; j < n; j++) // Sonuç matrisinin sütun döngüsü
            {
                Console.Write(resultMatrix[i, j] + "\t"); // Sonuç matrisinin her elemanını yazdır
            }
            Console.WriteLine(); // Bir satırı yazdırdıktan sonra yeni satıra geç
        }

        // Programın hemen kapanmasını önlemek için
        Console.WriteLine("\nÇıkmak için Enter'a basın."); // Kullanıcıya çıkma talimatı ver
        Console.ReadLine(); // Kullanıcıdan girdi bekle
    }
}
