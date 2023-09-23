using System;
using System.Collections.Generic;

namespace HastaneOtomasyonu
{
    class Program
    {
        static List<Hasta> hastalar = new List<Hasta>();
        static List<Randevu> randevular = new List<Randevu>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hastane Otomasyonu");

            while (true)
            {
                Console.WriteLine("\nMenü:");
                Console.WriteLine("1. Yeni Hasta Ekle");
                Console.WriteLine("2. Hasta Bilgilerini Görüntüle");
                Console.WriteLine("3. Yeni Randevu Ekle");
                Console.WriteLine("4. Randevu Bilgilerini Görüntüle");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");

                int secim;
                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim)
                    {
                        case 1:
                            HastaEkle();
                            break;
                        case 2:
                            HastaBilgileriniGoruntule();
                            break;
                        case 3:
                            RandevuEkle();
                            break;
                        case 4:
                            RandevuBilgileriniGoruntule();
                            break;
                        case 5:
                            Console.WriteLine("Çıkış yapılıyor...");
                            return;
                        default:
                            Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir seçenek girin.");
                }
            }
        }

        static void HastaEkle()
        {
            Console.WriteLine("Yeni Hasta Ekle");
            Console.Write("Hasta Adı: ");
            string ad = Console.ReadLine();
            Console.Write("Hasta Soyadı: ");
            string soyad = Console.ReadLine();
            Console.Write("Yaş: ");
            int yas;
            if (int.TryParse(Console.ReadLine(), out yas))
            {
                Hasta hasta = new Hasta(ad, soyad, yas);
                hastalar.Add(hasta);
                Console.WriteLine("Hasta başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Geçersiz yaş değeri.");
            }
        }

        static void HastaBilgileriniGoruntule()
        {
            Console.WriteLine("Hasta Bilgilerini Görüntüle");
            Console.Write("Hasta Adı: ");
            string ad = Console.ReadLine();
            Console.Write("Hasta Soyadı: ");
            string soyad = Console.ReadLine();

            Hasta hasta = hastalar.Find(h => h.Ad == ad && h.Soyad == soyad);

            if (hasta != null)
            {
                Console.WriteLine("Hasta Bilgileri:");
                Console.WriteLine($"Ad: {hasta.Ad}");
                Console.WriteLine($"Soyad: {hasta.Soyad}");
                Console.WriteLine($"Yaş: {hasta.Yas}");
            }
            else
            {
                Console.WriteLine("Hasta bulunamadı.");
            }
        }

        static void RandevuEkle()
        {
            Console.WriteLine("Yeni Randevu Ekle");
            Console.Write("Hasta Adı: ");
            string ad = Console.ReadLine();
            Console.Write("Hasta Soyadı: ");
            string soyad = Console.ReadLine();

            Hasta hasta = hastalar.Find(h => h.Ad == ad && h.Soyad == soyad);

            if (hasta != null)
            {
                Console.Write("Randevu Tarihi: ");
                string tarih = Console.ReadLine();
                Console.Write("Randevu Saati: ");
                string saat = Console.ReadLine();

                Randevu randevu = new Randevu(hasta, tarih, saat);
                randevular.Add(randevu);

                Console.WriteLine("Randevu başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Hasta bulunamadı.");
            }
        }

        static void RandevuBilgileriniGoruntule()
        {
            Console.WriteLine("Randevu Bilgilerini Görüntüle");
            Console.Write("Hasta Adı: ");
            string ad = Console.ReadLine();
            Console.Write("Hasta Soyadı: ");
            string soyad = Console.ReadLine();

            Hasta hasta = hastalar.Find(h => h.Ad == ad && h.Soyad == soyad);

            if (hasta != null)
            {
                Console.WriteLine($"Randevuları: {hasta.Ad} {hasta.Soyad}");
                foreach (var randevu in randevular)
                {
                    if (randevu.Hasta == hasta)
                    {
                        Console.WriteLine($"Tarih: {randevu.Tarih}, Saat: {randevu.Saat}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Hasta bulunamadı.");
            }
        }
    }

    class Hasta
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

        public Hasta(string ad, string soyad, int yas)
        {
            Ad = ad;
            Soyad = soyad;
            Yas = yas;
        }
    }

    class Randevu
    {
        public Hasta Hasta { get; set; }
        public string Tarih { get; set; }
        public string Saat { get; set; }

        public Randevu(Hasta hasta, string tarih, string saat)
        {
            Hasta = hasta;
            Tarih = tarih;
            Saat = saat;
        }
    }
}

