using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
    public class LinkedListOtelYorum : ListADT
    {
        public override void DeleteFirst()
        {
            throw new NotImplementedException();
        }

        public override void DeleteLast()
        {
            throw new NotImplementedException();
        }

        public override void DeletePosition(int pos)
        {
            throw new NotImplementedException();
        }

        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            OtelBilgi Otel_Yorum;
            while (item != null)
            {
                //todo : alttaki değişken değerlerini aktar

                Otel_Yorum = (OtelBilgi)item.Data;

                temp += "YorumSahibiAd" +Otel_Yorum.otelYorum.YorumSahibiAd + "YorumSahibiSoyad " + Otel_Yorum.otelYorum.YorumSahibiSoyad +
                "Posta" + Otel_Yorum.otelYorum.Posta + "Yorum " + Otel_Yorum.otelYorum.Yorum;
                item = item.Next;
            }

            return temp;
        }

        public override Node Find(int tc)
        {
            throw new NotImplementedException();
        }

        public override int GetElement(int tc)
        {
            throw new NotImplementedException();
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
