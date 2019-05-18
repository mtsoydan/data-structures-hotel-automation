using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{

    public class HashMapChain
    {
        int tabloBoyutu = 10;

        linkedHashEntry[] tablo;
        public Heap h;


        public HashMapChain()
        {
            tablo= new linkedHashEntry[tabloBoyutu];
            for (int i = 0; i < tabloBoyutu; i++)
                tablo[i] = null;
        }
        public void Add(string key, OtelBilgi value)
        {
            int hash = hashFonksiyonu(key, 10);
            if (tablo[hash] == null)
            {
                tablo[hash] = new linkedHashEntry(key, value);
                tablo[hash].h = new Heap(100);
                tablo[hash].h.InsertOtel(value);
            }
            else
            {
                linkedHashEntry entry = tablo[hash];
                while (entry.Next != null && entry.Anahtar == key)
                    entry = entry.Next;
                //tablo[hash] = new HashEntry(key, value);
                tablo[hash].h = new Heap(100);
                tablo[hash].h.InsertOtel(value);
                //if (entry.Anahtar == key)
                //    entry.Deger = value;
                //else
                entry.Next = new linkedHashEntry(key, value);
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
        public string GetPersonel(string key)
        {
            int hash = hashFonksiyonu(key,10);
            if (tablo[hash] == null)
                return null;
            else
            {
                linkedHashEntry entry = tablo[hash];
                while (entry != null && entry.Anahtar == key)
                    entry = entry.Next;
                //if (entry == null)
                //    return null;
                //else
                    return entry.Deger.ToString();
            }
        }


    }


}

