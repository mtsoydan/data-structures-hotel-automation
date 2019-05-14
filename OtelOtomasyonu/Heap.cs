using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
   public class Heap
    {
        //public HeapDugumu[] heapArrayYıldız;
        public HeapDugumu[] heapArrayPuan;

        private int maxSize;
        public int currentSize;

        public Heap(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            currentSize = 0;
            //heapArrayYıldız = new HeapDugumu[maxSize];
            heapArrayPuan = new HeapDugumu[maxSize];


        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }

        //public bool InsertYıldız(OtelBilgi o)
        //{
        //    if (currentSize == maxSize)
        //        return false;
        //    HeapDugumu newHeapDugumu = new HeapDugumu(o);
        //    heapArrayYıldız[currentSize] = newHeapDugumu;
        //    MoveToUpYıldız(currentSize++);
        //    return true;
        //}

        //private void MoveToUpYıldız(int v)
        //{
        //    throw new NotImplementedException();
        //}

        public bool InsertPuan(OtelBilgi o)
        {
            if (currentSize == maxSize)
                return false;
            HeapDugumu newHeapDugumu = new HeapDugumu(o);
            heapArrayPuan[currentSize] = newHeapDugumu;
            MoveToUpPuan(currentSize++);
            return true;
        }

        private void MoveToUpPuan(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArrayPuan[index];
            while (index > 0 && heapArrayPuan[parent].otel.OtelPuani < bottom.otel.OtelPuani)
            {
                heapArrayPuan[index] = heapArrayPuan[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArrayPuan[index] = bottom;

        }

        public HeapDugumu RemoveMax()
        {
            HeapDugumu root = heapArrayPuan[0];
            heapArrayPuan[0] = heapArrayPuan[--currentSize];
            MoveToDown(0);
            return root;
        }

        public OtelBilgi MaxHeapGetir()
        {
            return heapArrayPuan[0].otel;
        }

        private void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArrayPuan[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;

                if (rightChild < currentSize && heapArrayPuan[leftChild].otel.OtelPuani < heapArrayPuan[rightChild].otel.OtelPuani)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (top.otel.OtelPuani >= heapArrayPuan[largerChild].otel.OtelPuani)
                    break;
                heapArrayPuan[index] = heapArrayPuan[largerChild];
                index = largerChild;
            }
            heapArrayPuan[index] = top;
        }

        public string DisplayHeap()
        {
            string temp = "";

            for (int m = 0; m < currentSize; m++)
            {
                if (heapArrayPuan[m] != null)
                    temp += "Adı-Soyadı:" + (heapArrayPuan[m].otel.OtelAdi + " " + "İl-İlçe:" + heapArrayPuan[m].otel.Il + heapArrayPuan[m].otel.Ilce +
                        "Adresi:" + heapArrayPuan[m].otel.Adres + " " + "E-posta:" + heapArrayPuan[m].otel.EPosta + " "+
                         "Telefon Numarası:" + heapArrayPuan[m].otel.Telefon + " " + "Yıldız Sayısı:"
                        + heapArrayPuan[m].otel.YildizSayisi + " " + "Oda Sayısı: " + heapArrayPuan[m].otel.OdaSayisi + " " + "Oda Tipi:" + heapArrayPuan[m].otel.OdaTipi +" "+
                        "Otel Puanı:" + heapArrayPuan[m].otel.OtelPuani) + Environment.NewLine;
                //"Mezun Bilgileri--> " + heapArray[m].ogr.MezunBilgiListesi.DisplayElements()) + Environment.NewLine + Environment.NewLine;
                else
                    temp += ("-- ");
            }
            return temp;


        }

        public string PuanaGoreListele(int puan)
        {
            string temp = "";

            for (int m = 0; m < currentSize; m++)
            {
                if (heapArrayPuan[m] != null && heapArrayPuan[m].otel.OtelPuani == puan )
                    temp += "Adı-Soyadı:" + (heapArrayPuan[m].otel.OtelAdi + " " + "İl-İlçe:" + heapArrayPuan[m].otel.Il + heapArrayPuan[m].otel.Ilce +
                        "Adresi:" + heapArrayPuan[m].otel.Adres + " " + "E-posta:" + heapArrayPuan[m].otel.EPosta + " " +
                         "Telefon Numarası:" + heapArrayPuan[m].otel.Telefon + " " + "Yıldız Sayısı:"
                        + heapArrayPuan[m].otel.YildizSayisi + " " + "Oda Sayısı: " + heapArrayPuan[m].otel.OdaSayisi + " " + "Oda Tipi:" + heapArrayPuan[m].otel.OdaTipi + " " +
                        "Otel Puanı:" + heapArrayPuan[m].otel.OtelPuani) + Environment.NewLine;

            }

            return temp;
        }

        public HeapDugumu ElemanSil(OtelBilgi otel)
        {
            int indis = 0;
            for (int i = 0; i < heapArrayPuan.Length; i++)
            {
                if (heapArrayPuan[i].otel.OtelID == otel.OtelID)
                {
                    indis = i;
                    break;
                }
            }
            HeapDugumu root = heapArrayPuan[indis];
            heapArrayPuan[indis] = heapArrayPuan[--currentSize];
            MoveToDown(indis);
            return root;
        }

    }
}
