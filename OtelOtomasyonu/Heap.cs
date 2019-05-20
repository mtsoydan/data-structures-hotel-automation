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

        public bool InsertOtel(OtelBilgi o)
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
            MoveToDownPuan(0);
            return root;
        }

        public OtelBilgi MaxHeapGetir()
        {
            return heapArrayPuan[0].otel;
        }

        private void MoveToDownPuan(int index)
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

        public string PuanaGoreListele()
        {
            string temp = "";

            for (int i = 0; i < currentSize; i++)
            {
                if (heapArrayPuan[i] != null)
                {

                    temp += ">>Otel Adı:" + (heapArrayPuan[i].otel.OtelAdi + " " + "İl-İlçe:" + heapArrayPuan[i].otel.Il_Ilce +
                        "Adresi:" + heapArrayPuan[i].otel.Adres + " " + "E-posta:" + heapArrayPuan[i].otel.EPosta + " " +
                         "Telefon Numarası:" + heapArrayPuan[i].otel.Telefon + " " + "Yıldız Sayısı:"
                        + heapArrayPuan[i].otel.YildizSayisi + " " + "Oda Sayısı: " + heapArrayPuan[i].otel.OdaSayisi + " " + "Oda Tipi:" + heapArrayPuan[i].otel.OdaTipi + " " +
                        "Otel Puanı:" + heapArrayPuan[i].otel.OtelPuani) + Environment.NewLine + Environment.NewLine;
                }
                else
                    temp += ("-- ");
            }
            return temp;

        }
        public string YıldızaGoreAra(int yildiz)
        {
            string temp = "";
            for (int i = 0; i < currentSize; i++)
            {
                if (heapArrayPuan[i] != null && heapArrayPuan[i].otel.YildizSayisi == yildiz)
                {
                    temp += ">>Otel Adı:" + (heapArrayPuan[i].otel.OtelAdi + " " + "İl-İlçe:" + heapArrayPuan[i].otel.Il_Ilce +
                    "Adresi:" + heapArrayPuan[i].otel.Adres + " " + "E-posta:" + heapArrayPuan[i].otel.EPosta + " " +
                    "Telefon Numarası:" + heapArrayPuan[i].otel.Telefon + " " + "Yıldız Sayısı:"
                     + heapArrayPuan[i].otel.YildizSayisi + " " + "Oda Sayısı: " + heapArrayPuan[i].otel.OdaSayisi + " " + "Oda Tipi:" + heapArrayPuan[i].otel.OdaTipi + " " +
                    "Otel Puanı:" + heapArrayPuan[i].otel.OtelPuani) + Environment.NewLine + Environment.NewLine;

                }
                else
                    temp += ("-- ");
            }

            return temp;
        }

        //public string PuanaGoreListele()
        //{
        //    string temp = "";

        //    for (int i = 0; i < currentSize; i++)
        //    {
        //       // if (heapArrayPuan[m] != null && heapArrayPuan[m].otel.OtelPuani == puan )
        //            temp += "Adı-Soyadı:" + (heapArrayPuan[i].otel.OtelAdi + " " + "İl-İlçe:" + heapArrayPuan[i].otel.Il_Ilce+
        //                "Adresi:" + heapArrayPuan[i].otel.Adres + " " + "E-posta:" + heapArrayPuan[i].otel.EPosta + " " +
        //                 "Telefon Numarası:" + heapArrayPuan[i].otel.Telefon + " " + "Yıldız Sayısı:"
        //                + heapArrayPuan[i].otel.YildizSayisi + " " + "Oda Sayısı: " + heapArrayPuan[i].otel.OdaSayisi + " " + "Oda Tipi:" + heapArrayPuan[i].otel.OdaTipi + " " +
        //                "Otel Puanı:" + heapArrayPuan[i].otel.OtelPuani) + Environment.NewLine;

        //    }

        //    return temp;
        //}

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
            MoveToDownPuan(indis);
            return root;
        }

    }
}
