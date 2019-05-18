using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{

    public class linkedHashEntry
    {
        public Heap h;
        private string anahtar;

        private object deger;

        private linkedHashEntry next;

        public object Deger
        {
            get { return deger; }
            set { deger = value; }
        }
        public string Anahtar
        {
            get { return anahtar; }
            set { anahtar = value; }
        }


        public linkedHashEntry Next
        {
            get { return next; }
            set { next = value; }
        }


        public linkedHashEntry(string anahtar, object deger)
        {
            this.anahtar = anahtar;
            this.deger = deger;
            this.next = null;
        }

    }

}