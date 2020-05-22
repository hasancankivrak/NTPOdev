using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabevi.Sistemi
{
    class Kitap
    {
        public Kitap()
        {

        }
        public Kitap(string kadi, string yazar, string tur, DateTime basımtarihi)
        {
            Kitapadi = kadi;
            Yazar = yazar;
            Turu = tur;
            Basimtarihi = basımtarihi;
        }
        static string kadi;
        static string yazar;
        static string tur;
        private static DateTime basimtarihi;
        static int adet, date;

        public static string Kitapadi { get => kadi; set => kadi = value; }
        public static string Yazar { get => yazar; set => yazar = value; }
        public static string Turu { get => tur; set => tur = value; }
        public static DateTime Basimtarihi { get => basimtarihi; set => basimtarihi = value; }

        public static void Ekle()
        {
            Console.Write("Kaç Kitap Eklemek İstiyorsunuz ? ");
            adet = int.Parse(Console.ReadLine());
            Kitap[] dizi = new Kitap[adet];
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.WriteLine("Kitap Adını Giriniz");
                Kitapadi = Console.ReadLine();
                Console.WriteLine("Kitap Yazarını Giriniz");
                Yazar = Console.ReadLine();
                Console.WriteLine("Kitap Türünü Giriniz");
                Turu = Console.ReadLine();
                Console.WriteLine("Basım Yılını Giriniz");
                try
                {
                    do
                    {
                        date = int.Parse(Console.ReadLine());
                        if (date > 2020)
                        {
                            Console.WriteLine("2021`den Küçük Girmelisiniz");
                        }
                    } while (date > 2020);
                    Basimtarihi = new DateTime(date, 1, 1);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Yıl Olarak Belirtilmelidir");
                }             
                Kitap book = new Kitap(Kitapadi, Yazar, Turu, Basimtarihi);
                dizi[i] = book;
                Kıtapyaz(dizi,i);
            }
        }
        public string BookInfo()
        {
            return $"Kitap Adı: " + Kitapadi + " Yazar Adı: " + Yazar + "  Kitap Türü: " + Turu + "  Basım Yılı: " + Basimtarihi.Year;
        }
        public static void Kıtapyaz(Kitap[] dizi,int i)
        {
            FileStream fs = new FileStream("C:/kayit.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(dizi[i].BookInfo());
            fs.Flush();
            sw.Close();
            fs.Close();
        }
        public static void KitapGoruntule()
        {
            try
            {   
                using (StreamReader sr = new StreamReader("C:/kayit.txt"))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Bu dosya şu anda okunamaz:");
                Console.WriteLine(e.Message);
            }
        }
    }

}