using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OtelOtomasyonu
{
    public class HashMap
    {
        public HashEntry[] tablo;
        int tabloBoyutu = 10;
        public Heap h;

        public HashMap()
        {
            tablo = new HashEntry[10];
            for (int i = 0; i < 10; i++)
            {
                tablo[i] = null;
            }
        }
        public void Add(string key, OtelBilgi value)
        {
            int hash = hashFonksiyonu(key, 10);
            int a = hash;
            //while (tablo[hash] != null && tablo[hash].anahtar != key)
            //{
            //    hash = (hash + 1) % tabloBoyutu;
            //}
            //tablo[hash] = new HashEntry(key, value);
            //tablo[hash].h = new Heap(100);
            //tablo[hash].h.InsertOtel(value);


            if (tablo[hash] == null)
            {
                tablo[hash] = new HashEntry(key, value);
                tablo[hash].h = new Heap(100);
                tablo[hash].h.InsertOtel(value);
            }
            else
            {
                while (tablo[hash] != null)
                {
                    hash = (hash + 1) % tabloBoyutu;
                }
                tablo[a].h.InsertOtel(value);

            }

        }

        public int hashFonksiyonu(string key, int tabloBoyutu)
        {
            int sonuc = 0;

            int hashDeger = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hashDeger += key[i];

            }
            sonuc = hashDeger % tabloBoyutu; //tablo boyutuna göre mo alma
            return sonuc;
        }
        public void OtelBilgiGuncelle(Heap h, OtelBilgi otel)
        {
            for (int i = 0; i < h.currentSize; i++)
            {
                if (h.heapArrayPuan[i].otel.OtelID == otel.OtelID)
                    h.heapArrayPuan[i].otel = otel;
            }
        }
        
        public string GetOtelBilgiPuan(string anahtar)
        {
          
            int hash = hashFonksiyonu(anahtar, 10);
            while (tablo[hash] != null && tablo[hash].anahtar != anahtar)
            {
                 hash = (hash + 1) % tabloBoyutu;
            }
           
            return tablo[hash].h.PuanaGoreListele();

        }
         //while (tablo[hash] != null )
         //   {
         //       if (tablo[hash].anahtar == anahtar)
         //       {
         //           temp += tablo[hash].h.PuanaGoreListele();
         //           hash = (hash + 1) % tabloBoyutu;
         //       }
         //       else
         //       {
         //           hash = (hash + 1) % tabloBoyutu;
         //       }
                
               
         //   }
           
         //   return temp;
        public string GetOtelBilgiYildiz(string anahtar,int yildiz)
        {
            int hash = hashFonksiyonu(anahtar, 10);
            while (tablo[hash] != null && tablo[hash].anahtar != anahtar)
                hash = (hash + 1) % tabloBoyutu;
            if (tablo[hash] == null)
                return null;
            else
                return tablo[hash].h.YıldızaGoreAra(yildiz);

        }
    }
}



