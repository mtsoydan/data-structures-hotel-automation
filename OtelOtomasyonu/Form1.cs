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
        HashMap hashMap = new HashMap();
        OtelBilgi otel;
        List<OtelBilgi> ListOtel = new List<OtelBilgi>();
        List<PersonelBilgi> ListPer = new List<PersonelBilgi>();
         
        int otelId = 9;

        //xml den otel çekiliyor
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
            XDocument xDoc = XDocument.Load(@"C:\Users\ZİŞAN\Documents\GitHub\OtelOtomasyon\OtelBilgi.xml");
            XElement rootElement = xDoc.Root;
            foreach (XElement otelXml in rootElement.Elements())
            {
                otel = new OtelBilgi();
                //xml den otel bilgilerini çekme
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

                XmlPersonelListele(otel.OtelID, otel);//Şu andaki otelin otel ID si yollanır
                aramaAgaci.OtelEkle(otel);
                hashMap.Add(otel.Il_Ilce, otel);
                
            }
        }
        //yukarıda çekmiş olduğumuz otelin personel biliglerini xml den alıyoruz
        public void XmlPersonelListele(int OtelID, OtelBilgi _o)
        {
            XDocument xDoc = XDocument.Load(@"C:\Users\ZİŞAN\Documents\GitHub\OtelOtomasyon\PersonelBilgi.xml");
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

                    _o.PersonelBilgiList.InsertLast(otel.personelBilgi);//otelin içine eleman kaydedilir
                    
                }

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
                //puana göre, listeleme tüm oteller
                aramaAgaci.PostOrder();
                textListeleOtel.Text = aramaAgaci.DugumleriYazdir();
            }
        }
        

        private void btn_girisYap_Click(object sender, EventArgs e)
        {
            if (txt_kullaniciAdi.Text == "m" && txt_sifre.Text == "m")
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
            otel.Il_Ilce = cmbBox_ililceOtel.Text;
            otel.Adres = txt_otelAdres.Text;
            otel.EPosta = txt_OtelPosta.Text;
            otel.OdaSayisi = Convert.ToInt32(txt_OtelOdaSayisi.Text);
            otel.Telefon = txt_OtelTelefon.Text;
            otel.YildizSayisi = Convert.ToInt32(txt_OtelYildiz.Text);
            otel.OdaTipi = txt_OtelOdaTipi.Text;

            hashMap.Add(otel.Il_Ilce, otel);//
            aramaAgaci.OtelEkle(otel);//
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklendi");

        }
        //seçilen ilk ilçeye göre otel listeleme
        private void cmbBox_ililce_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBox_otelListe.Enabled = true;
                string anahtar = cmbBox_ililce.SelectedItem.ToString();
                textListeleOtel.Text = hashMap.GetOtelBilgiPuan(anahtar);
            }
            catch (Exception)
            {

                MessageBox.Show("Otel Bulunamadı");
            }
          
        }
        //orel güncelleniyor
        private void btn_otelGuncelle_Click(object sender, EventArgs e)
        {
         
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_gOtelAd.SelectedItem.ToString() == o.OtelAdi)
                {
                    o.Il_Ilce = cmbBox_gILIlce.Text;
                    o.Adres = txt_gOtelAdres.Text;
                    o.EPosta = txt_gOtelTelefon.Text;
                    o.Telefon = txt_gOtelPosta.Text;
                    o.OdaSayisi = Convert.ToInt32(txt_gOtelYildiz.Text);
                    o.OdaTipi = txt_gOtelOdaSayisi.Text;
                    o.OtelPuani = Convert.ToInt32(txt_gOtelOdaTipi.Text);
                    o.YildizSayisi = Convert.ToInt32(cmbBox_gOtelPuan.Text);
                    
                    //agac ve hash içinde güncelleme
                    aramaAgaci.OtelBilgiGuncelle(o);
                    int hIndis = hashMap.hashFonksiyonu(o.Il_Ilce, 10);
                    hashMap.OtelBilgiGuncelle(hashMap.tablo[hIndis].h, o);
                    break;
                }
            }

            MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi");

        }

        private void btn_OtelSil_Click(object sender, EventArgs e)
        {
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_otelSil.SelectedItem.ToString() == o.OtelAdi)
                {
                    aramaDugum = aramaAgaci.OtelIDAra(o.OtelID);
                    aramaAgaci.OtelSil(aramaDugum.veri.OtelID);
                    string anahtar = aramaDugum.veri.Il_Ilce;
                    int hIndis = hashMap.hashFonksiyonu(anahtar, 10);
                    hashMap.tablo[hIndis].h.ElemanSil(aramaDugum.veri);
                }
            }
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi");
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
        //seçilmiş il-ilçedeki otellrin puan ve yıldıza göre listelenmesi
        private void cmbBox_otelListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBox_otelListe.Text == "Puan")
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
            int yildiz = int.Parse(cmbBox_yildiz.SelectedItem.ToString());
            textListeleOtel.Text = hashMap.GetOtelBilgiYildiz(anahtar, yildiz);
        }
        //combobox lara otel isimlerini yerleştirme
        private void OtelDoldurCmbBox()
        {
            int i = 0;
            cmbBox_otelAdi.Items.Clear();
            cmbBox_gOtelAd.Items.Clear();
            cmbBox_otelSil.Items.Clear();
            cmbBox_perOtel.Items.Clear();
            cmbBox_pergOtel.Items.Clear();
            cmbBox_Psil.Items.Clear();
            cmbBox_PerOtelPuanla.Items.Clear();
            cmbBoxPerDepartmanOtelListeleme.Items.Clear();

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
            cmbBox_Psil.Items.AddRange(temp);
            cmbBox_PerOtelPuanla.Items.AddRange(temp);
            cmbBoxPerDepartmanOtelListeleme.Items.AddRange(temp);

        }
        //otele puan verme
        private void btn_otelPuanVer_Click(object sender, EventArgs e)
        {
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_otelAdi.SelectedItem.ToString() == o.OtelAdi)
                {
                    int temp = o.OtelPuani;
                    temp += Convert.ToInt32(cmbBox__otelPuan.Text);
                    o.OtelPuani = temp / 2;
                    aramaAgaci.OtelBilgiGuncelle(o);
                    int hIndis = hashMap.hashFonksiyonu(o.Il_Ilce, 10);
                    hashMap.OtelBilgiGuncelle(hashMap.tablo[hIndis].h, o);
                    break;
                }
            }
           
            MessageBox.Show("Puan verildi");

        }

        private void btn_yorumYap_Click(object sender, EventArgs e)
        {
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_otelAdi.SelectedItem.ToString() == o.OtelAdi)
                {
                    o.otelYorum = new OtelYorum();
                    o.otelYorum.YorumSahibiAd = "Ali";
                    o.otelYorum.YorumSahibiSoyad = "Veli";
                    o.otelYorum.Posta = "aliveli@gmail.com";
                    o.otelYorum.Yorum = txt_yorum.Text;
                    o.OtelYorumList.InsertLast(o);
                    aramaAgaci.OtelBilgiGuncelle(o);
                    break;
                }
            }
            
            MessageBox.Show("Yorum Yapıldı");
        }
        //personel kayıt 
        private void btn_perKaydet_Click(object sender, EventArgs e)
        {
          
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

                    o.PersonelBilgiList.InsertLast(o.personelBilgi);//
                    aramaAgaci.OtelBilgiGuncelle(o);//

          
                    break;
                }
            }
            MessageBox.Show("Yeni personel eklendi ");
        }

      
        private void btn_perGuncelle_Click(object sender, EventArgs e)
        {
            ListPer = aramaAgaci.perListe();
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_pergOtel.SelectedItem.ToString() == o.OtelAdi)
                {
                    PersonelBilgiGuncelle(o);
                    break;
                }
            }
        }
        //listeden güncellenecek personel  bilgisini getirme
        private void btn_perGetir_Click(object sender, EventArgs e)
        {
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_pergOtel.SelectedItem.ToString() == o.OtelAdi)
                {
                    List<PersonelBilgi> list = o.PersonelBilgiList.ListePersonel();
                    PersonelDoldurText(list);
                    break;
                }
            }
        }
        private void PersonelBilgiGuncelle(OtelBilgi o)
        {
      
            foreach (PersonelBilgi p in ListPer)
            {
                if (p.TC == int.Parse(txt_gPerTc.Text))
                {
                    
                    p.Ad = txt_gPerAd.Text;
                    p.Soyad = txt_gPerSoyad.Text;
                    p.Adres = txt_gPerAdres.Text;
                    p.Telefon = txt_gPerTelefon.Text;
                    p.EPosta = txt_gPerPosta.Text;
                    p.Departman = txt_gPerDepartman.Text;
                    p.Pozisyon = txt_gPerPozisyon.Text;
                    p.PersonelPuani = Convert.ToInt32(txt_gPerPuan.Text);

                    o.PersonelBilgiList.Find(p.TC).Data = p;
                    aramaAgaci.OtelBilgiGuncelle(o);
                    break;
                }
            }

        }
        //TC ye göre aranan personele puan ekleme
        private void PersonelPuanEkle(OtelBilgi o)
        {
           
            foreach (PersonelBilgi p in ListPer)
            {
                if (p.TC == int.Parse(txt_puanlaTC.Text))
                {

                    p.PersonelPuani =int.Parse( cmbBox_perPuan.SelectedItem.ToString());

                    o.PersonelBilgiList.Find(p.TC).Data = p;
                    aramaAgaci.OtelBilgiGuncelle(o);
                    break;
                }
            }

        }
        
        private void PersonelDoldurText(List<PersonelBilgi> list)
        {
            foreach (PersonelBilgi p in list)
            {
                if (p.TC == int.Parse(txt_gPerTc.Text))
                {
                    txt_gPerAd.Text = p.Ad;
                    txt_gPerSoyad.Text = p.Soyad;
                    txt_gPerAdres.Text = p.Adres;
                    txt_gPerTelefon.Text = p.Telefon;
                    txt_gPerPosta.Text = p.EPosta;
                    txt_gPerDepartman.Text = p.Departman;
                    txt_gPerPozisyon.Text = p.Pozisyon;
                    txt_gPerPuan.Text = p.PersonelPuani.ToString();
                    break;
                }
                
            }
        }
        //puan verilecek personel için tc ile arama
        private void PuanlamaPersonelDoldur(List<PersonelBilgi> list)
        {
            foreach (PersonelBilgi p in list)
            {
                if (p.TC == int.Parse(txt_puanlaTC.Text))
                {
                    txt_PuanlaPerAdi.Text = p.Ad;
                    txt_PerPuanlaDepartman.Text = p.Departman;
                    break;
                }


            }
        }
        //Personel silme
    private void btn_perSil_Click(object sender, EventArgs e)
        {
            ListPer = aramaAgaci.perListe();

            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_Psil.SelectedItem.ToString() == o.OtelAdi)
                {
                    foreach (PersonelBilgi p in ListPer)
                    {
                        if (Convert.ToInt32(txt_SilPerTc.Text) == p.TC)
                        {
                            int pos = o.PersonelBilgiList.GetElement(p.TC);

                            o.PersonelBilgiList.DeletePosition(pos);

                            aramaAgaci.OtelBilgiGuncelle(o);

                            break;
                        }
                    }
                    break;
                }
            }
            
            MessageBox.Show("Kayıt silindi");
        }

      //personele puan verilir
        private void btn_PerPuanVer_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (OtelBilgi o in ListOtel)
                {
                    if (cmbBox_PerOtelPuanla.SelectedItem.ToString() == o.OtelAdi)
                    {
                        PersonelPuanEkle(o);
                        break;
                    }
                }
                MessageBox.Show("Personel Puanlaması Başarılı");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        //önce oteli sonra personel seçilerek departman listelenir.
        private void btn_departman_Click(object sender, EventArgs e)
        {
            ListPer = aramaAgaci.perListe();

            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBoxPerDepartmanOtelListeleme.SelectedItem.ToString() == o.OtelAdi)
                {
                    List<PersonelBilgi> list = o.PersonelBilgiList.ListePersonel();
                    foreach (PersonelBilgi p in list)
                    {
                        if (p.Departman == cmbBox_departman.SelectedItem.ToString())
                        {
                            lstBox_personel.Items.Add(p.TC);
                            lstBox_personel.Items.Add(p.Ad);
                            lstBox_personel.Items.Add(p.Soyad);

                            lstBox_personel.Items.Add(p.Adres);
                            lstBox_personel.Items.Add(p.Pozisyon);
                            lstBox_personel.Items.Add(p.PersonelPuani);
                            lstBox_personel.Items.Add("*************************************");

                        }
                    }
                    break;
                }
            }

        }
        //personel getirme puanlamak için
        private void btn_personelPuanGetir_Click_1(object sender, EventArgs e)
        {
            ListPer = aramaAgaci.perListe();

            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBox_PerOtelPuanla.SelectedItem.ToString() == o.OtelAdi)
                {
                    List<PersonelBilgi> list = o.PersonelBilgiList.ListePersonel();
                    PuanlamaPersonelDoldur(list);
                    break;
                }
            }
        }
        //yuksek puanlı personeli linked listten getirme
        private void btn_yuksekPuanPer_Click(object sender, EventArgs e)
        {
            foreach (OtelBilgi o in ListOtel)
            {
                if (cmbBoxPerDepartmanOtelListeleme.SelectedItem.ToString() == o.OtelAdi)
                {

                    lstBox_personel.Items.Add(o.PersonelBilgiList.EnYukekPersonel(o));
                }
            }
        }
    }
}






