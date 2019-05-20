using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
  public abstract  class ListADT
    {
        public Node Head;
        public int Size = 0;
        public abstract void InsertFirst(object value);
        public abstract void InsertLast(object value);
        //public abstract void DeleteFirst();
        //public abstract void DeleteLast();
        //public abstract Node Find(int tc);
        //public abstract void DeletePosition(int pos);
        //public abstract int GetElement(int tc);
        public abstract string DisplayElements();

    }
}
