using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabevi.Sistemi
{
    class Program : Kitap
    {
        static void Main(string[] args)
        {        
            char cevap;
            Console.WriteLine("Kütüphanemize Hoşgeldiniz");   
            do
            {           
                
                Console.WriteLine("Hangi işlemi seçmek istiyorsunuz");
                Console.WriteLine("1-Kitap Ekleme");
                Console.WriteLine("2-Kitapları Görüntüleme");
                char islem = Convert.ToChar(Console.ReadLine());
                if (islem == '1')
                {
                    Kitap.Ekle();
                }
                else if (islem == '2')
                {
                    Kitap.KitapGoruntule(); 
                }
                else
                {
                    Console.WriteLine("Hatalı Giriş");
                }
                Console.WriteLine("Devam Etmek İstiyor Musunuz ? (e/h)");
                cevap = Convert.ToChar(Console.ReadLine());
            } while (cevap == 'e');
            Console.WriteLine("Bizi Seçtiğiniz İçin Teşekkür Ederiz.");
            Console.ReadKey();
        }
    }
}
