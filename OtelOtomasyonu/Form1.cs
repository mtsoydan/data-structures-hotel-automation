using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txt_sifre.PasswordChar = '*';

        }
        IkiliAramaAgaciDugumu aramaDugum;
        IkiliAramaAgaci aramaAgaci = new IkiliAramaAgaci();
       // LinkedListPersonelBİlgi linkedPer = new LinkedListPersonelBİlgi();
       //  LinkedListOtelYorum linkedYorum = new LinkedListOtelYorum();
        HashMap hashMap = new HashMap();
        HashMapChain mapChain = new HashMapChain();
        OtelBilgi otel;
        List<OtelBilgi> ListOtel = new List<OtelBilgi>();

       //ersonelBilgi per;
        //OtelYorum yorum;     
        int otelId =9;


        private void Form1_Load(object sender, EventArgs e)
        {
            cmbBox_ililce.Enabled = false;
            cmbBox_otelListe.Enabled = false;
            cmbBox_yildiz.Enabled = false;
            XmlOtelListele();
            aramaAgaci.DerinlikBul();
            lbl_derinlik.Text = aramaAgaci.Yukseklik.ToString();
            lbl_eleman.Text = aramaAgaci.DugumSayisi().ToString();
            OtelDoldurCmbBox();

        }
        public void XmlOtelListele()
        {
            aramaAgaci = new IkiliAramaAgaci();
            XDocument xDoc = XDocument.Load(@"C:\Users\BHR\Documents\GitHub\OtelOtomasyon\OtelBilgi.xml");
            XElement rootElement = xDoc.Root;
            foreach (XElement otelXml in rootElement.Elements())
            {
                otel = new OtelBilgi();
                //xml den çekme
                otel.OtelID = Convert.ToInt32(otelXml.Attribute("id").Value);
                otel.OtelAdi = otelXml.Element("OtelAdi").Value;
                otel.Il_Ilce = otelXml.Element("Il_Ilce").Value;
                otel.Adres = otelXml.Element("Adres").Value;
                otel.Telefon = otelXml.Element("Telefon").Value;
                otel.EPosta = otelXml.Element("EPosta").Value;
                otel.YildizSayisi = Convert.ToInt32(otelXml.Element("YildizSayisi").Value);
                otel.OdaSayisi = Convert.ToInt32(otelXml.Element("OdaSayisi").Value);
                otel.OdaTipi = otelXml.Element("OdaTipi").Value;
                otel.OtelPuani = Convert.ToInt32(otelXml.Element("OtelPuani").Value);
                //otel.PersonelBilgiList.InsertLast(XmlPersonelListele(otel.OtelID));
                //arama ağacına ve hash e ekleme
                //otel.PersonelBilgiList.InsertLast(XmlPersonelListele(otel.OtelID,otel));
                XmlPersonelListele(otel.OtelID, otel);//Şu andaki otelin otel ID si yollanır
                // cmbBox_perOtel.Items.Add(otel.OtelAdi);
                aramaAgaci.OtelEkle(otel);
                hashMap.Add(otel.Il_Ilce, otel);


            }
        }
        public void XmlPersonelListele(int OtelID,OtelBilgi _o)
        {
            XDocument xDoc = XDocument.Load(@"C:\Users\BHR\Documents\GitHub\OtelOtomasyon\PersonelBilgi.xml");
            XElement rootElement = xDoc.Root;
            foreach (XElement perXml in rootElement.Elements())
            {
                if (int.Parse(perXml.Element("OtelId").Value) == OtelID)
                {
                    otel.personelBilgi = new PersonelBilgi();
                    otel.personelBilgi.TC = Convert.ToInt32(perXml.Attribute("id").Value);
                    otel.personelBilgi.Ad = perXml.Element("Ad").Value;
                    otel.personelBilgi.Soyad = perXml.Element("Soyad").Value;
                    otel.personelBilgi.Adres = perXml.Element("Adres").Value;
                    otel.personelBilgi.Telefon = perXml.Element("Telefon").Value;
                    otel.personelBilgi.EPosta = perXml.Element("EPosta").Value;
                    otel.personelBilgi.Departman = perXml.Element("Departman").Value;
                    otel.personelBilgi.Pozisyon = perXml.Element("Pozisyon").Value;
                    otel.personelBilgi.PersonelPuani = Convert.ToInt32(perXml.Element("PersonelPuani").Value);
                   // per.TC = Convert.ToInt32(perXml.Attribute("id").Value);
                   // per.Ad = perXml.Element("Ad").Value;
                   // per.Soyad = perXml.Element("Soyad").Value;
                   //per.Adres = perXml.Element("Adres").Value;
                   // per.Telefon = perXml.Element("Telefon").Value;
                   // per.EPosta = perXml.Element("EPosta").Value;
                   // per.Departman = perXml.Element("Departman").Value;
                   // per.Pozisyon = perXml.Element("Pozisyon").Value;
                   // per.PersonelPuani = Convert.ToInt32(perXml.Element("PersonelPuani").Value);
                    _o.PersonelBilgiList.InsertLast(otel.personelBilgi);//otelin içine eleman kaydedilir
                }
               
            }
        }




        public void XmlPersonelListele()
        {
            PersonelBilgi per = new PersonelBilgi();
            XDocument xDoc = XDocument.Load(@"C:\Users\asus\Documents\GitHub\OtelOtomasyon\PersonelBilgi.xml");
            XElement rootElement = xDoc.Root;
            foreach (XElement perXml in rootElement.Elements())
            {
               
                //xml den çekme
                per.TC = Convert.ToInt32(perXml.Attribute("id").Value);
                per.Ad = perXml.Element("Ad").Value;
                per.Soyad = perXml.Element("Soyad").Value;
                per.Adres = perXml.Element("Adres").Value;
                per.Telefon = perXml.Element("Telefon").Value;
                per.EPosta = perXml.Element("EPosta").Value;
                per.Departman = perXml.Element("Departman").Value;
                per.Pozisyon = perXml.Element("Pozisyon").Value;
                per.PersonelPuani = Convert.ToInt32(perXml.Element("PersonelPuani").Value);

                 aramaAgaci.OtelIDAra(Convert.ToInt32(perXml.Element("OtelId").Value));
                 ///

                //arama agacına ekleyelim
                 otel.PersonelBilgiList.InsertLast(per);

            }
        }
        private void cmbBox_otelListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBox_otelListele.Text == "İl-İlçe")
            {
                cmbBox_ililce.Enabled = true;
                textListeleOtel.Text = "";
            }
            else
            {
                //listeleme tüm oteller
                aramaAgaci.PostOrder();
                textListeleOtel.Text = aramaAgaci.DugumleriYazdir();
            }
        }

        private void cmbBox_il_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBox_gIL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_girisYap_Click(object sender, EventArgs e)
        {
            if(txt_kullaniciAdi.Text=="m"&&txt_sifre.Text=="m")
            {
                tabCtrl.Controls.Remove(tbpDuzenle);
                tabCtrl2.Controls.Remove(tbpListelePersonel);
                tabCtrl2.Controls.Remove(tbpPuanlaPersonel);
                
            }
            else if (txt_kullaniciAdi.Text == "a" && txt_sifre.Text == "a")
            {
                tabCtrl2.Controls.Remove(tbpPuanOtel);
                tabCtrl2.Controls.Remove(tbpListeleOtel);

            }
            else
                MessageBox.Show("Giriş Başarısız");

            txt_kullaniciAdi.Text = "";
            txt_sifre.Text = "";
            tabCtrl.SelectedIndex = 1;
        }

        private void btn_OtelKaydet_Click(object sender, EventArgs e)
        {
            OtelBilgi otel = new OtelBilgi();
            otel.OtelID = otelId++;
            otel.OtelAdi = txt_otelAdi.Text;
            otel.Il_Ilce = cmbBox_ililce.Text;
            otel.Adres= txt_otelAdres.Text;
            otel.EPosta = txt_OtelPosta.Text;
            otel.OdaSayisi = Convert.ToInt32(txt_OtelOdaSayisi.Text);
            otel.Telefon = txt_OtelTelefon.Text;
            otel.YildizSayisi = Convert.ToInt32(txt_OtelYildiz.Text);
            otel.OtelPuani = Convert.ToInt32("") ;
            otel.OdaTipi = txt_OtelOdaTipi.Text;

            hashMap.Add(otel.Il_Ilce, otel);
            aramaAgaci.OtelEkle(otel);
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklendi");

        }
        private void cmbBox_ililce_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBox_otelListe.Enabled = true;
            string anahtar = cmbBox_ililce.SelectedItem.ToString();
            //int hIndis = hashMap.hashFonksiyonu(anahtar, 10);
            //textListeleOtel.Text = hashMap.tablo[hIndis].h.PuanaGoreListele();
            textListeleOtel.Text = hashMap.GetOtelBilgiPuan(anahtar);
        }
        
        private void btn_otelGuncelle_Click(object sender, EventArgs e)
        {
            OtelBilgi otel = new OtelBilgi();
           
                if (otel.OtelAdi== cmbBox_gOtelAd.Text)
                {
               // otel.OtelID = ;
                otel.Il_Ilce = cmbBox_gOtelILce.Text;
                otel.Adres = txt_gOtelAdres.Text;
                otel.EPosta = txt_gOtelTelefon.Text;
                otel.Telefon = txt_gOtelPosta.Text;
                otel.OdaSayisi =Convert.ToInt32( txt_gOtelYildiz.Text);
                otel.OdaTipi = txt_gOtelOdaSayisi.Text;
                otel.OtelPuani= Convert.ToInt32(txt_gOtelOdaTipi.Text);
                otel.YildizSayisi = Convert.ToInt32(cmbBox_gOtelPuan.Text);
                }
                //agac ve hash içinde güncelleme
            aramaAgaci.OtelBilgiGuncelle(otel);
            int hIndis = hashMap.hashFonksiyonu(otel.Il_Ilce, 10);
            hashMap.OtelBilgiGuncelle(hashMap.tablo[hIndis].h, otel);
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi");

        }
       
        private void btn_OtelSil_Click(object sender, EventArgs e)
        {
            OtelBilgi otel = new OtelBilgi();
            otel.OtelID = Convert.ToInt32(cmbBox_otelSil.Text);

            aramaDugum = aramaAgaci.OtelIDAra(Convert.ToInt32(cmbBox_otelSil.Text));
            aramaAgaci.OtelSil(otel.OtelID);
            string anahtar = aramaDugum.veri.Il_Ilce;
            int hIndis = hashMap.hashFonksiyonu(anahtar, 3);
            hashMap.tablo[hIndis].h.ElemanSil(aramaDugum.veri);
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi");

        }

        private void tbpListeleOtel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_departman_Click(object sender, EventArgs e)
        {

        }

        private void btn_preOrder_Click(object sender, EventArgs e)
        {
            aramaAgaci.PreOrder();
            textListeleOtel.Text = aramaAgaci.DugumleriYazdir();
        }

        private void btn_intOrder_Click(object sender, EventArgs e)
        {
            aramaAgaci.InOrder();
            textListeleOtel.Text = aramaAgaci.DugumleriYazdir();
        }

        private void btn_postOrder_Click(object sender, EventArgs e)
        {
            aramaAgaci.PostOrder();
            textListeleOtel.Text = aramaAgaci.DugumleriYazdir();
        }

        private void cmbBox_otelListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBox_otelListe.Text=="Puan")
            {
                string anahtar = cmbBox_ililce.SelectedItem.ToString();
                textListeleOtel.Text = hashMap.GetOtelBilgiPuan(anahtar);
            }
            else
            {
                cmbBox_yildiz.Enabled = true;
            }
        }

        private void cmbBox_yildiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            string anahtar = cmbBox_ililce.SelectedItem.ToString();
            int yildiz= int.Parse(cmbBox_yildiz.SelectedItem.ToString());
            textListeleOtel.Text = hashMap.GetOtelBilgiYildiz(anahtar, yildiz);
        }

        private void cmbBox_departman_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            aramaAgaci.PostOrder();
           //lstBox_personel.Items.Add(aramaAgaci)
        }
        private void OtelDoldurCmbBox()
        {
            int i = 0;
            cmbBox_otelAdi.Items.Clear();
            cmbBox_gOtelAd.Items.Clear();
            cmbBox_otelSil.Items.Clear();
            cmbBox_perOtel.Items.Clear();
            cmbBox_pergOtel.Items.Clear();

            aramaAgaci.PreOrder();
            ListOtel = aramaAgaci.otelListe();
            string[] temp = new string[ListOtel.Count];
            foreach (OtelBilgi o in ListOtel)
            {
                temp[i] = o.OtelAdi;
                i++;
            }
            cmbBox_otelAdi.Items.AddRange(temp);
            cmbBox_gOtelAd.Items.AddRange(temp);
            cmbBox_otelSil.Items.AddRange(temp);
            cmbBox_perOtel.Items.AddRange(temp);
            cmbBox_pergOtel.Items.AddRange(temp);


        }
        private void btn_otelPuanVer_Click(object sender, EventArgs e)
        {
            OtelBilgi ob = new OtelBilgi();
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_otelAdi.SelectedItem.ToString() == o.OtelAdi)
                {
                    int temp = o.OtelPuani;
                    temp += Convert.ToInt32(cmbBox__otelPuan.Text);
                    o.OtelPuani = temp / 2;

                    ob.OtelID = o.OtelID;
                    ob.OtelAdi = o.OtelAdi;
                    ob.Il_Ilce = o.Il_Ilce;
                    ob.Adres = o.Adres;
                    ob.EPosta = o.EPosta;
                    ob.Telefon = o.Telefon;
                    ob.OdaSayisi = o.OdaSayisi;
                    ob.OdaTipi = o.OdaTipi;
                    ob.OtelPuani = o.OtelPuani;
                    ob.YildizSayisi = o.YildizSayisi;
                    break;
                }

            }
            aramaAgaci.OtelBilgiGuncelle(ob);
            int hIndis = hashMap.hashFonksiyonu(ob.Il_Ilce, 10);
            hashMap.OtelBilgiGuncelle(hashMap.tablo[hIndis].h, ob);
            MessageBox.Show("Puan verildi");

        }

        private void btn_yorumYap_Click(object sender, EventArgs e)
        {
            OtelBilgi ob = new OtelBilgi();
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_otelAdi.SelectedItem.ToString() == o.OtelAdi)
                {
                    ob.otelYorum.YorumSahibiAd = "Ali";
                    ob.otelYorum.YorumSahibiSoyad = "Veli";
                    ob.otelYorum.Posta = "aliveli@gmail.com";
                    ob.otelYorum.Yorum = txt_yorum.Text;

                    ob.OtelID = o.OtelID;
                    ob.OtelAdi = o.OtelAdi;
                    ob.Il_Ilce = o.Il_Ilce;
                    ob.Adres = o.Adres;
                    ob.EPosta = o.EPosta;
                    ob.Telefon = o.Telefon;
                    ob.OdaSayisi = o.OdaSayisi;
                    ob.OdaTipi = o.OdaTipi;
                    ob.OtelPuani = o.OtelPuani;
                    ob.YildizSayisi = o.YildizSayisi;
                    break;
                }
            }
            ob.OtelYorumList.InsertLast(ob);
            aramaAgaci.OtelBilgiGuncelle(ob);
            MessageBox.Show("Yorum Yapıldı");
        }

        private void btn_perKaydet_Click(object sender, EventArgs e)
        {
            // OtelBilgi ob = new OtelBilgi();
            //otel.personelBilgi = new PersonelBilgi();
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_perOtel.SelectedItem.ToString() == o.OtelAdi)
                {
                    o.personelBilgi = new PersonelBilgi();
                    o.personelBilgi.Ad = txt_perAd.Text;
                    o.personelBilgi.Soyad = txt_perSoyad.Text;
                    o.personelBilgi.Adres = txt_perAdres.Text;
                    o.personelBilgi.Departman = txt_perDepartman.Text;
                    o.personelBilgi.EPosta = txt_perPosta.Text;
                    o.personelBilgi.PersonelPuani = int.Parse(txt_perPuan.Text);
                    o.personelBilgi.Pozisyon = txt_perPozisyon.Text;
                    o.personelBilgi.TC = int.Parse(txt_perTC.Text);
                    o.personelBilgi.Telefon = txt_perTelefon.Text;

                    o.PersonelBilgiList.InsertLast(o.personelBilgi);
                    aramaAgaci.OtelBilgiGuncelle(o);

                    //ob.OtelID = o.OtelID;
                    //ob.OtelAdi = o.OtelAdi;
                    //ob.Il_Ilce = o.Il_Ilce;
                    //ob.Adres = o.Adres;
                    //ob.EPosta = o.EPosta;
                    //ob.Telefon = o.Telefon;
                    //ob.OdaSayisi = o.OdaSayisi;
                    //ob.OdaTipi = o.OdaTipi;
                    //ob.OtelPuani = o.OtelPuani;
                    //ob.YildizSayisi = o.YildizSayisi;
                    break;
                }
            }

            //ob.PersonelBilgiList.InsertLast(ob);
            //aramaAgaci.OtelBilgiGuncelle(ob);
            MessageBox.Show("yeni personel eklendi ");


        }

        private void cmbBox_otelAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBox_gOtelAd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBox_otelSil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBox_perOtel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBox_pergOtel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}






