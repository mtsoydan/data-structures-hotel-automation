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
                //todo : alttaki değişken değerlerini aktar

                Personel_Bilgi = (PersonelBilgi)item.Data;
                listPer.Add(Personel_Bilgi);
                temp += "Personel TC " + Personel_Bilgi.TC + " " + "Personel Adı" + Personel_Bilgi.Ad + Personel_Bilgi.Soyad +
                "Telefon" + Personel_Bilgi.Telefon + "Adres " + Personel_Bilgi.Adres + " Eposta " + Personel_Bilgi.EPosta + Environment.NewLine;
                item = item.Next;
            }

            return temp;
        }
        public List<PersonelBilgi> ListePersonel()
        {
            return listPer;
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

        public override void DeleteFirst()
        {
            if (Head != null)
            {
                Node tempHeadNext = this.Head.Next;
                if (tempHeadNext == null)
                {
                    Head = null;
                }
                else
                {
                    Head = tempHeadNext;
                    Size--;
                }

            }
        }

        public override void DeleteLast()
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

        public override void DeletePosition(int pos)
        {
            Node posNode = Head;
            Node prevPosNode = null;
            int count = 0;
            while (posNode != null)
            {
                if (count == pos)
                {
                    prevPosNode.Next = posNode.Next;
                    posNode = null;
                }
                posNode = posNode.Next;
                count++;
            }
        }

        public override int GetElement(int tc)
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

        public override Node Find(int tc)
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
