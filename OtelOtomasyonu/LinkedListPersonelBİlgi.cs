using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
    public class LinkedListPersonelBİlgi : ListADT
    {
        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            PersonelBilgi Personel_Bilgi;
            while (item != null)
            {
                //todo : alttaki değişken değerlerini aktar
                Personel_Bilgi = (PersonelBilgi)item.Data;
              //  temp += "Personel TC " + Personel_Bilgi.TC + " "+ "Personel Adı" +Personel_Bilgi.Ad + Personel_Bilgi.Soyad +"Telefon" +Personel_Bilgi.Telefon +"Adres "+ Personel_Bilgi.Adres + " Eposta " + Personel_Bilgi.EPosta+ "departman   
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
    }
}
