using System;

class PrimeSum
{
    public static void Main(string[] args)
    {
        // Kullanıcıdan N sayısını al
        Console.WriteLine("N sayısını giriniz:");
        int n = int.Parse(Console.ReadLine()); // Kullanıcının girdiği değeri al ve tamsayıya dönüştür

        int sum = 0; // Asal sayıların toplamı için bir değişken oluştur
        // 2'den N'ye kadar döngü başlat
        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i)) // i sayısının asal olup olmadığını kontrol et
            {
                sum += i; // Eğer asal ise toplam değişkenine ekle
            }
        }

        // Sonucu ekrana yazdır
        Console.WriteLine($"1'den {n} kadar olan asal sayıların toplamı: {sum}");

        // Programın hemen kapanmasını önlemek için
        Console.WriteLine("\nÇıkmak için Enter'a basın.");
        Console.ReadLine(); // Kullanıcıdan girdi bekle
    }

    // Asal sayıları kontrol eden metod
    public static bool IsPrime(int number)
    {
        if (number < 2) return false; // 2'den küçük sayılar asal değildir
        for (int i = 2; i <= Math.Sqrt(number); i++) // 2'den başlayarak sayının kareköküne kadar kontrol et
        {
            if (number % i == 0) // Eğer number i'ye tam bölünüyorsa asal değildir
                return false;
        }
        return true; // Tüm kontrollerden geçerse asal sayıdır
    }
}
