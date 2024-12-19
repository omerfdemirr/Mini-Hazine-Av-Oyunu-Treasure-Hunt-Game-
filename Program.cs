using System;

namespace MiniHazineAvıOyunu
{
    class Program
    {
        static int[,] oyunAlani = new int[10, 10];
        static (int, int) hazineKonumu;
        static (int, int) oyuncuKonumu = (0, 0); // Oyuncu sol üst köşede başlar.

        static void Main(string[] args)
        {
            RastgeleHazineKonumuBelirle();

            while (true)
            {
                Console.Clear();
                OyunAlaniniGoster();
                HazineyeUzaklik();

                Console.WriteLine("Hareket etmek için yön seçin: (w: yukarı, s: aşağı, a: sol, d: sağ)");
                char hareket = Console.ReadKey().KeyChar;

                if (!OyuncuyuHareketEttir(hareket))
                {
                    Console.WriteLine("\nGeçersiz hareket! Duvara çarptınız.");
                    Console.ReadKey();
                    continue;
                }

                if (oyuncuKonumu == hazineKonumu)
                {
                    Console.Clear();
                    OyunAlaniniGoster();
                    Console.WriteLine("\nTebrikler! Hazineyi buldunuz!!!");
                    break;
                }
            }
        }

        static void RastgeleHazineKonumuBelirle()
        {
            Random rnd = new Random();
            hazineKonumu = (rnd.Next(0, 10), rnd.Next(0, 10));
        }

        static void OyunAlaniniGoster()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (oyuncuKonumu == (i, j))
                        Console.Write("O "); // Oyuncunun olduğu yer
                    else
                        Console.Write(". "); // Boş hücre
                }
                Console.WriteLine();
            }
        }

        static void HazineyeUzaklik()
        {
            int uzaklik = Math.Abs(oyuncuKonumu.Item1 - hazineKonumu.Item1) +
                          Math.Abs(oyuncuKonumu.Item2 - hazineKonumu.Item2);
            Console.WriteLine($"\nHazineye olan uzaklık: {uzaklik} birim.");
        }

        static bool OyuncuyuHareketEttir(char hareket)
        {
            switch (hareket)
            {
                case 'w': // Yukarı
                    if (oyuncuKonumu.Item1 > 0)
                    {
                        oyuncuKonumu.Item1--;
                        return true;
                    }
                    break;
                case 's': // Aşağı
                    if (oyuncuKonumu.Item1 < 9)
                    {
                        oyuncuKonumu.Item1++;
                        return true;
                    }
                    break;
                case 'a': // Sol
                    if (oyuncuKonumu.Item2 > 0)
                    {
                        oyuncuKonumu.Item2--;
                        return true;
                    }
                    break;
                case 'd': // Sağ
                    if (oyuncuKonumu.Item2 < 9)
                    {
                        oyuncuKonumu.Item2++;
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
