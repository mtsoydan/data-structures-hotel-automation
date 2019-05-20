using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
    public class LinkedListPersonelBİlgi : ListADT
    {
        List<PersonelBilgi> listPer = new List<PersonelBilgi>();

        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            PersonelBilgi Personel_Bilgi;
            while (item != null)
            {
                Personel_Bilgi = (PersonelBilgi)item.Data;
                listPer.Add(Personel_Bilgi);
                temp += "Personel TC: " + Personel_Bilgi.TC + " " + "Personel Adı: " + Personel_Bilgi.Ad + Personel_Bilgi.Soyad +
                "Telefon: " + Personel_Bilgi.Telefon + "Adres: " + Personel_Bilgi.Adres + " Eposta: " + Personel_Bilgi.EPosta + " Departman: "
                +Personel_Bilgi.Departman+ "Pozisyon: "+Personel_Bilgi.Pozisyon+"Personel Puanı: "+Personel_Bilgi.PersonelPuani + Environment.NewLine;
                item = item.Next;
            }

            return temp;
        }
        public List<PersonelBilgi> ListePersonel()
        {
            return listPer;
        }
        public string EnYukekPersonel(OtelBilgi otel)
        {
            string temp = "";
            int tmp1 = 0 ;
            Node item = Head;
            
            PersonelBilgi p;
            while (item != null)
            {
                p = (PersonelBilgi)item.Data;
                for (int i = 0; i < otel.PersonelBilgiList.Size; i++)
                {
                    if (p.PersonelPuani > tmp1 && otel.PersonelBilgiList.listPer[i].Ad == p.Ad  )
                {
                    tmp1 = p.PersonelPuani;
                    temp = "";
                    temp ="En Yüksek Puanlı Personel--"+Environment.NewLine+ p.Ad +"-"+p.Soyad + "- "+ p.PersonelPuani.ToString();
                }
            }
               
                item = item.Next;
                
            }
            return temp;
        }
        public override void InsertFirst(object value)
        {

            Node tmpHead = new Node
            {
                Data = value
            };


            if (Head == null)
                Head = tmpHead;
            else
            {

                tmpHead.Next = Head;
                Head = tmpHead;
            }
            Size++;
        }

        public override void InsertLast(object value)
        {
            Node oldLast = Head;

            if (Head == null)
                InsertFirst(value);
            else
            {
                Node newLast = new Node
                {
                    Data = value
                };

                while (oldLast != null)
                {
                    if (oldLast.Next != null)
                        oldLast = oldLast.Next;
                    else
                        break;
                }


                oldLast.Next = newLast;
                Size++;
            }
        }

        public  void DeleteFirst()
        {
            //if (Head != null)
            //{
            //    Node tempHeadNext = this.Head.Next;
            //    if (tempHeadNext == null)
            //    {
            //        Head = null;
            //    }
            //    else
            //    {
            //        Head = tempHeadNext;
            //        Size--;
            //    }

            //}
            Node temp = this.Head.Next;
            if (temp.Next == null)
            {
                Head = null;
            }
            else
            {
                Head = temp;
                Size--;
            }
        }

        public  void DeleteLast()
        {
            Node lastNode = Head;
            Node lastPrevNode = null;
            while (lastNode.Next != null)
            {
                lastPrevNode = lastNode;
                lastNode = lastNode.Next;
            }
            Size--;
            lastNode = null;
            if (lastPrevNode != null)
            {
                lastPrevNode.Next = null;
            }
            else
                Head = null;
        }

        public  void DeletePosition(int position)
        {
            Node posNode = Head;
            Node prevPosNode = null;
            int count = 0;
            while (posNode != null)
            {
                if (count == position)
                {
                    prevPosNode.Next = posNode.Next;
                    posNode = null;
                    break;
                }
                prevPosNode = posNode;
                posNode = posNode.Next;
                count++;
            }
            //Node tmp = Head;
            //Node tmpPrev = null;
            //int sayac = 0;
            //while (tmp != null)
            //{
            //    if (position < Size)
            //    {
            //        if (tmpPrev == null)
            //        {
            //            DeleteFirst();
            //            break;
            //        }
            //        if (sayac == (position))
            //        {

            //            tmpPrev.Next = tmp.Next;
            //            tmp = null;
            //            Size--;
            //            break;
            //        }
            //        tmpPrev = tmp;
            //        tmp = tmp.Next;
            //        sayac++;
            //    }





            //}
        }

      


        public  int GetElement(int tc)
        {
            PersonelBilgi per;
            Node tempHead = Head;
            int count = 0;
            int temp = 0;

            while (tempHead != null)
            {
                per = (PersonelBilgi)tempHead.Data;

                if (per.TC == tc)
                {
                    temp = count;
                }
                tempHead = tempHead.Next;
                count++;
            }
            return temp;
        }

        public  Node Find(int tc)
        {
            Node retNode = null;
            Node tempNode = Head;
            PersonelBilgi per;

            while (tempNode != null)
            {
                per = (PersonelBilgi)tempNode.Data;
                if (per.TC == tc)
                {
                    retNode = tempNode;
                    break;

                }
                tempNode = tempNode.Next;

            }
            return retNode;
        }
    }

}