using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
 public   class HashEntry
    {
        public string anahtar { get; set; }
        public OtelBilgi Deger { get; set; } 
        public Heap h;

        public HashEntry(string anahtar,OtelBilgi deger)
        {
            this.anahtar = anahtar;
            this.Deger = deger;
        }
    }
}
