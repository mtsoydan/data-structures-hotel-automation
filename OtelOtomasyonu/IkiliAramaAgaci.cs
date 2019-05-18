using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
    public class IkiliAramaAgaci
    {
        private IkiliAramaAgaciDugumu kok;
        List<OtelBilgi> otelList = new List<OtelBilgi>();

        private string dugumler;
        public string tempOrtalama = "";
        public string advancedTemp = " ";
        public bool kilit = false;
        public int Yukseklik = -1;

        public IkiliAramaAgaci()
        {

        }
        public IkiliAramaAgaci(IkiliAramaAgaciDugumu kok)
        {
            this.kok = kok;
        }

        public int DugumSayisi()
        {
            return DugumSayisi(kok);
        }
        public string DugumleriYazdir()
        {
            return dugumler;
        }
        public int DugumSayisi(IkiliAramaAgaciDugumu dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                count = 1;
                count += DugumSayisi(dugum.sol);
                count += DugumSayisi(dugum.sag);
            }
            return count;
        }
        public List<OtelBilgi> otelListe()
        {
            return otelList;
        }
        public void PreOrder()
        {
            dugumler = "";
            PreOrderInt(kok);
        }
        private void PreOrderInt(IkiliAramaAgaciDugumu dugum)
        {
            if (dugum == null)
                return;
            Ziyaret(dugum);
            PreOrderInt(dugum.sol);
            PreOrderInt(dugum.sag);
        }
        private void Ziyaret(IkiliAramaAgaciDugumu dugum)
        {
            otelList.Add(dugum.veri);
            dugumler += "Adı: " + dugum.veri.OtelAdi + " " + "Il-Ilçe: " + dugum.veri.Il_Ilce + " " + "Adres: " + dugum.veri.Adres + " " +
            "Telefon: " + dugum.veri.Telefon + " " + "EPosta: " + dugum.veri.EPosta + " " + "Yıldız Sayısı: " + dugum.veri.YildizSayisi + " "+
            "Oda Sayısı: " + dugum.veri.OdaSayisi + " " + "Oda Tipi: " + dugum.veri.OdaTipi + " " + "Puan: " + dugum.veri.OtelPuani +
            Environment.NewLine + "Otel Yorumları--> " + dugum.veri.OtelYorumList.DisplayElements() + Environment.NewLine+ Environment.NewLine+
            "Personel Bilgileri--> " + dugum.veri.PersonelBilgiList.DisplayElements() + Environment.NewLine + Environment.NewLine;
        }
        


        public void InOrder()
        {
            dugumler = "";
            InOrderInt(kok);
        }
        private void InOrderInt(IkiliAramaAgaciDugumu dugum)
        {
            if (dugum == null)
                return;
            InOrderInt(dugum.sol);
            Ziyaret(dugum);
            InOrderInt(dugum.sag);
        }
        public void PostOrder()
        {
            dugumler = "";
            PostOrderInt(kok);
        }
        private void PostOrderInt(IkiliAramaAgaciDugumu dugum)
        {
            if (dugum == null)
                return;
            PostOrderInt(dugum.sol);
            PostOrderInt(dugum.sag);
            Ziyaret(dugum);
        }
        public IkiliAramaAgaciDugumu OtelIDAra(int anahtar)
        {
            return OtelIDAraInt(kok, anahtar);
        }
        private IkiliAramaAgaciDugumu OtelIDAraInt(IkiliAramaAgaciDugumu dugum,
                                            int anahtar)
        {
            if (dugum == null)
                return null;
            else if ((int)dugum.veri.OtelID == anahtar)
                return dugum;
            else if ((int)dugum.veri.OtelID > anahtar)
                return (OtelIDAraInt(dugum.sol, anahtar));
            else
                return (OtelIDAraInt(dugum.sag, anahtar));
        }

        public void OtelEkle(OtelBilgi deger)
        {

            IkiliAramaAgaciDugumu tempParent = new IkiliAramaAgaciDugumu();

            IkiliAramaAgaciDugumu tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;

                if (deger.OtelID == tempSearch.veri.OtelID)
                    return;
                else if (deger.OtelID < tempSearch.veri.OtelID)
                    tempSearch = tempSearch.sol;
                else
                    tempSearch = tempSearch.sag;
            }
            IkiliAramaAgaciDugumu eklenecek = new IkiliAramaAgaciDugumu(deger);

            if (kok == null)
                kok = eklenecek;
            else if (deger.OtelID < tempParent.veri.OtelID)
                tempParent.sol = eklenecek;
            else
                tempParent.sag = eklenecek;
        }


        private IkiliAramaAgaciDugumu Successor(IkiliAramaAgaciDugumu silDugum)
        {
            IkiliAramaAgaciDugumu successorParent = silDugum;
            IkiliAramaAgaciDugumu successor = silDugum;
            IkiliAramaAgaciDugumu current = silDugum.sag;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.sol;
            }
            if (successor != silDugum.sag)
            {
                successorParent.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;
        }
        public bool OtelSil(int deger)
        {
            IkiliAramaAgaciDugumu current = kok;
            IkiliAramaAgaciDugumu parent = kok;
            bool issol = true;
            //DÜĞÜMÜ BUL
            while ((int)current.veri.OtelID != deger)
            {
                parent = current;
                if (deger < (int)current.veri.OtelID)
                {
                    issol = true;
                    current = current.sol;
                }
                else
                {
                    issol = false;
                    current = current.sag;
                }
                if (current == null)
                    return false;
            }
            //DURUM 1: YAPRAK DÜĞÜM
            if (current.sol == null && current.sag == null)
            {
                if (current == kok)
                    kok = null;
                else if (issol)
                    parent.sol = null;
                else
                    parent.sag = null;
            }
            //DURUM 2: TEK ÇOCUKLU DÜĞÜM
            else if (current.sag == null)
            {
                if (current == kok)
                    kok = current.sol;
                else if (issol)
                    parent.sol = current.sol;
                else
                    parent.sag = current.sol;
            }
            else if (current.sol == null)
            {
                if (current == kok)
                    kok = current.sag;
                else if (issol)
                    parent.sol = current.sag;
                else
                    parent.sag = current.sag;
            }
            //DURUM 3: İKİ ÇOCUKLU DÜĞÜM
            else
            {
                IkiliAramaAgaciDugumu successor = Successor(current);
                if (current == kok)
                    kok = successor;
                else if (issol)
                    parent.sol = successor;
                else
                    parent.sag = successor;
                successor.sol = current.sol;
            }
            return true;
        }

        public IkiliAramaAgaciDugumu OtelBilgiGuncelle(OtelBilgi otel)
        {
            return OtelBilgiGuncelle(kok, otel);
        }
        private IkiliAramaAgaciDugumu OtelBilgiGuncelle(IkiliAramaAgaciDugumu dugum, OtelBilgi otel)
        {

            if ((int)dugum.veri.OtelID == otel.OtelID)
            {
                dugum.veri = otel;
                return dugum;
            }
            else if ((int)dugum.veri.OtelID > otel.OtelID)
                return (OtelBilgiGuncelle(dugum.sol, otel));
            else
                return (OtelBilgiGuncelle(dugum.sag, otel));
        }


        public void PreOrderAdvanced(OtelBilgi otel)
        {
            ZiyaretAdvanced(kok, otel);
        }


        private void ZiyaretAdvanced(IkiliAramaAgaciDugumu dugum, OtelBilgi otel)
        {

            if (dugum == null)
                return;

            if (dugum.veri.YildizSayisi == otel.YildizSayisi)
            {
                advancedTemp += "Otel Adı:" + dugum.veri.OtelAdi + Environment.NewLine;
            }

            ZiyaretAdvanced(dugum.sol, otel);
            ZiyaretAdvanced(dugum.sag, otel);

        }

        private void DerinlikBulInt(IkiliAramaAgaciDugumu dugum)
        {
            if (dugum == null)
                return;
            else
            {
                Yukseklik++;
                DerinlikBulInt(dugum.sol); //Düğümün solu oldukça sola git


            }
        }

        public void DerinlikBul()
        {
            Yukseklik = -1;
            DerinlikBulInt(kok);
        }
    }
}
//Otel ID si 1 olan otellerin personellerini listelemek