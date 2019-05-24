# OtelOtomasyon

MCBU software engineering is the first project of data structures.

                                         MANİSA CELAL BAYAR ÜNİVERSİTESİ

                                    VERİ YAPILARI DERSİ DÖNEM PROJESİ DÖKÜMANI
                                                OTEL BİLGİ SİSTEMİ
                                                    (2018-2019)

PROJE EKİBİ

Berkan ŞAŞMAZ - 182803002 (https://github.com/berkansasmaz)

Bahar YILMAZ - 172802013 (https://github.com/BaharYilmaz)

Mustafa Taha SOYDAN - 162805003 (https://github.com/Mtsoydan)

Zişan KARSATAR - 172802058 (https://github.com/zisankarsatar)

#1 Ödevin Gerçekleştirildiği Platform ve Sürümü, Kullanılan Dil <br> <br>
Microsoft Visual Studio 2017- C#, XML

#2 Gerçekleştirilen Projenin Kısa Tanımı  <br>  
Geliştirdiğimiz otel bilgi sisteminde otellere ait bilgiler bulundurmaktadır. Ayrıca her bir otelde çalışan kişi ve otel yorumları bulunmaktadır. Yönetici girişi ile otel ve personel bilgilerini güncellenip, silme işlemi yapılmaktadır. Yeni otel ve personel de eklenebilmektedir. Personellere puan verebilir en yüksek puana sahip personel gösterebilmektedir.
Müşteriler de bu sisteme giriş yapıp, aradıkları il-ilçe’deki tüm otel bilgilerini listeleyip görebilir. Ayrıca, o il-ilçe’deki en yüksek otel puanına sahip olan otelleri ve seçmiş oldukları yıldız sayısına sahip olan otelleri filtreleyip, listeleyebilmektedir. Otele ve personele puan verebilir, yorumda bulunabilir.
#3 Veri Yapısı Kataloğu  <br>  
1-Kullanılan Veri Yapıları  <br>
Linked List: Elemanlarının bir sonraki (Next) elemanın hafızadaki yerine işaret ettiği zincir şeklinde bir veri yapısıdır.
İkili Arama Ağacı: Doğrusal olmayan belirli niteliklere sahip iki boyutlu veri yapılarıdır.
Heap: Eksiksiz (complete) r ve Ebeveyn (parent) düğümün değeri her zaman çocukların değerinden büyük (küçük) veya eşit olan ikili ağaçtır.
Hash Table: Aranan anahtar elemana doğrudan erişerek aradığımız indexi bulmaya yarayan veri yapısıdır.
2-Kullanılan Classlar  <br>
HashEntry: Bu class’ta hash tablomuzun propertyleri bulunmaktadır.
<br>HashMap: Hash tablomuz oluşmaktadır.
<br>Heap: Bu classta düğümlerimize otellerimizi otel puanına veya otel yıldız sayısına göre yerleştiriyoruz. 
<br>HeapDugumu: Heap için propertyler bulunmaktadır.
<br>IkiliAramaAgaci: Otel ID ile otelimiz aratılır. Otelimize otel ekleme/güncelleme/ silme ve personel ekleme işlemi yapılır. Ağacımız için düğüm sayısı hesaplanıp, derinlik bulunmaktadır. İnorder, postorder ve preorder gezinmeler yapılmaktadır.
<br>IkiliAramaAgaciDugumu: İkili arama ağacı için propertyler tanımlanmıştır.
<br>LinkedListOtelYorum: Otel yorumlarını linked liste ekleyebiliyoruz.
<br>LİnkedListPersonelBilgi: Personel bilgileri linked listte tutulur. Ekleme/Silme/Güncelleme işlemelerini yapılır ve TC’ye göre personel aratılır.
<br>ListADT: Linked listte kullanılmak üzere fonksiyonlar barındırmaktadır.
<br>Node: Linked listte kullanmak için oluşturulan nodeların classı.
<br>OtelBilgi: Otel Bilgi propertyleri.
<br>Otel Yorum: Otel yorumu propertyleri.
<br>PersonelBilgi: Personel ile ilgili propertyleri tutmaktadır.<br><br>
3-Kullanılan Metotlar  <br>
<br>InsertFirst: İlk elemanı eklemek için kullandığımız metottur.
<br>InsertLast: Son elemanı eklemek için kullandığımız metottur.
<br>EnYuksekPersonel: Girilen otel bilgisine göre otelin personel bilgisi bulunur ve en yüksek puanlı personel ekrana yazdırılır.
<br>DeleteFirst: Linked listten ilk elemanı silmek için kullandığımız metottur.
<br>DeleteLast: Linked listten son elemanı silmek için kullandığımız metottur.
<br>DeletePosition: Linked listten istenilen pozisyondaki elemanı silmek için kullandığımız metottur.
<br>GetElement: Gelen tc numarsına göre aranan eleman personel temp ile geri döndürülür.
<br>Node Find: Tc’ye göre linked listten personel bilgisi bulma.
<br>DugumSayisi: Ağacımızdaki düğüm sayısını hesaplar.
<br>PreOrderInt: Kök-Sol-Sağ gezinmesi.
<br>InOrderInt: Sol-Kök-Sağ gezinmesi.
<br>PostOrderInt: Sol-Sağ-Kök gezinmesi.
<br>Ziyaret: Gelen düğümdeki verilere erişme.
<br>OtelIDAraInt: Otel ID sine göre ikili ağaç düğümünde oteli aramamızı sağlar.
<br>OtelEkle: Gelen değere göre uygun düğüme otel ekleme.
<br>Successor: Düğüm silerken, silinen düğüm yerine en uygun düğümü getirmek için kullanıldı.
<br>OtelSil: Düğümlerden Otel silme işlemi.
<br>Add: Otel bilgisi eklemek için gelen anahtarı hashaFonsiyonu na gönderir. Gelen indise göre otel bilgisi hash tablosuna ve heap ağacına kaydedilir.
<br>hashFonksiyonu: String karakterlerin ASCII değerlerini toplayıp modunu alır ve geriye otel bilgisinin ekleneceği indisi döndürür.
<br>OtelBilgiGuncelle: Gelen otel bilgisine göre heap içinde güncelleme yapar.
<br>GetOtelBilgiPuan: Parametre olarak alınan anahtar değerine göre hash tablosuna yerleştirilir ve heap teki liste döndürülür.
<br>GetOtelBilgiYıldız: Gelen anahtar ve yıldız sayısına göre hash tablosunda yeri bulunur. Heap teki liste döndürülür.
<br>OtelPersonelEkle: Gelen düğümden otel ID sine göre linked listte teni personel ekleme.
<br>DerinlikBulInt: Ağaç derinliği hesaplama.
<br>InsertOtel: Otel bilgisini heap ağacına ekleriz.
<br>IsEmpty: Heap in boş olup olmadığı kontrol edilir.
<br>MoveToUpPuan: Eklenen yeni düğüm bir üst düğüm ile karşılaştırılarak uygun yere yerleştirilir.
<br>RemoveMax: Maximum değeri silme.
<br>MoveToDownPuan: Silinen elemandan sonra heap ağacını düzenler.
<br>PuanaGoreListele: Otel bilgilerini puana göre listeleme.
<br>YıldızaGöreAra: Otelleri yıldız sayısına göre arama yapmak için oluşturulmuş metot.
<br>ElemanSil: Gelen parametreye göre heap içinde arama yapar ve bulunan indisteki otel bilgisini siler.
<br><br>
#4 Proje Youtube Linki : https://youtu.be/EgisgFTPVhA 

<br>
#5 Proje GitHub Linki: https://github.com/mtsoydan/OtelOtomasyon
<br>
#6 Proje Gerçekleştiriminde Yararlanılan Kaynaklar
https://www.geeksforgeeks.org/
https://stackoverflow.com/


