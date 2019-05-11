using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
   public class OtelBilgi
    {
        public int OtelID { get; set; }
        public string OtelAdi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string EPosta { get; set; }


        public int YildizSayisi { get; set; }
        public int OdaSayisi { get; set; }
        public string OdaTipi { get; set; }
        public int OtelPuani { get; set; }

        public LinkedListOtelYorum OtelYorumList { get; set; }
        public LinkedListPersonelBİlgi PersonelBilgiList { get; set; }

        public OtelBilgi()
        {
            OtelYorumList = new LinkedListOtelYorum();
            PersonelBilgiList = new LinkedListPersonelBİlgi();

        }
    }
}
