﻿using System;
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
        IkiliAramaAgaciDugumu aramaDugum = new IkiliAramaAgaciDugumu();
        IkiliAramaAgaci aramaAgaci = new IkiliAramaAgaci();
       // LinkedListPersonelBİlgi linkedPer = new LinkedListPersonelBİlgi();
       //  LinkedListOtelYorum linkedYorum = new LinkedListOtelYorum();
        HashMapChain hashMap = new HashMapChain();
        OtelBilgi OtelBilgi;

        int otelId=5;


        private void Form1_Load(object sender, EventArgs e)
        {
            
            cmbBox_ililce.Enabled = false;
            cmbBox_otelListe.Enabled = false;
            XmlOtelListele();
        }
        public void XmlOtelListele()
        {
            OtelBilgi otel = new OtelBilgi();
            XDocument xDoc = XDocument.Load(@"C:\Users\BHR\Documents\GitHub\OtelOtomasyon\OtelBilgi.xml");
            XElement rootElement = xDoc.Root;
            foreach (XElement otelXml in rootElement.Elements())
            {

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
               
                //arama ağacına ve hash e ekleme
                hashMap.Add(otel.Il_Ilce, otel);
                aramaAgaci.OtelEkle(otel);
                
            }
        }

        public void XmlPersonelListele()
        {
            PersonelBilgi per = new PersonelBilgi();
            XDocument xDoc = XDocument.Load(@"C:\Users\BHR\Documents\GitHub\OtelOtomasyon\PersonelBilgi.xml");
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
                 OtelBilgi.PersonelBilgiList.InsertLast(per);

            }
        }
        private void cmbBox_otelListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBox_otelListele.Text == "İl-İlçe")
            {
                cmbBox_ililce.Enabled = true;
            }
            else
            {
                //listeleme tüm oteller
                //aramaAgaci.PostOrder();
                //textListeleOtel.Text = aramaAgaci.DugumleriYazdir();
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
            hashMap.OtelBilgiGuncelle(hashMap.table[hIndis].h, otel);
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
            hashMap.table[hIndis].h.ElemanSil(aramaDugum.veri);
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi");

        }

        private void tbpListeleOtel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}






