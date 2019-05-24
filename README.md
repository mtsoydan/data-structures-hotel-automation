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

#1 Ödevin Gerçekleştirildiği Platform ve Sürümü, Kullanılan Dil
Microsoft Visual Studio 2017- C#, XML

#2 Gerçekleştirilen Projenin Kısa Tanımı
Geliştirdiğimiz otel bilgi sisteminde otellere ait bilgiler bulundurmaktadır. Ayrıca her bir otelde çalışan kişi ve otel yorumları bulunmaktadır. Yönetici girişi ile otel ve personel bilgilerini güncellenip, silme işlemi yapılmaktadır. Yeni otel ve personel de eklenebilmektedir. Personellere puan verebilir en yüksek puana sahip personel gösterebilmektedir.
Müşteriler de bu sisteme giriş yapıp, aradıkları il-ilçe’deki tüm otel bilgilerini listeleyip görebilir. Ayrıca, o il-ilçe’deki en yüksek otel puanına sahip olan otelleri ve seçmiş oldukları yıldız sayısına sahip olan otelleri filtreleyip, listeleyebilmektedir. Otele ve personele puan verebilir, yorumda bulunabilir.
#3 Veri Yapısı Kataloğu
1-Kullanılan Veri Yapıları
Linked List: Elemanlarının bir sonraki (Next) elemanın hafızadaki yerine işaret ettiği zincir şeklinde bir veri yapısıdır.
İkili Arama Ağacı: Doğrusal olmayan belirli niteliklere sahip iki boyutlu veri yapılarıdır.
Heap: Eksiksiz (complete) r ve Ebeveyn (parent) düğümün değeri her zaman çocukların değerinden büyük (küçük) veya eşit olan ikili ağaçtır.
Hash Table: Aranan anahtar elemana doğrudan erişerek aradığımız indexi bulmaya yarayan veri yapısıdır.
2-Kullanılan Classlar
HashEntry: Bu class’ta hash tablomuzun propertyleri bulunmaktadır.
HashMap: Hash tablomuz oluşmaktadır.
Heap: Bu classta düğümlerimize otellerimizi otel puanına veya otel yıldız sayısına göre yerleştiriyoruz. 
HeapDugumu: Heap için propertyler bulunmaktadır.
IkiliAramaAgaci: Otel ID ile otelimiz aratılır. Otelimize otel ekleme/güncelleme/ silme ve personel ekleme işlemi yapılır. Ağacımız için düğüm sayısı hesaplanıp, derinlik bulunmaktadır. İnorder, postorder ve preorder gezinmeler yapılmaktadır.
IkiliAramaAgaciDugumu: İkili arama ağacı için propertyler tanımlanmıştır.
LinkedListOtelYorum: Otel yorumlarını linked liste ekleyebiliyoruz.
LİnkedListPersonelBilgi: Personel bilgileri linked listte tutulur. Ekleme/Silme/Güncelleme işlemelerini yapılır ve TC’ye göre personel aratılır.
ListADT: Linked listte kullanılmak üzere fonksiyonlar barındırmaktadır.
Node: Linked listte kullanmak için oluşturulan nodeların classı.
OtelBilgi: Otel Bilgi propertyleri.
Otel Yorum: Otel yorumu propertyleri.
PersonelBilgi: Personel ile ilgili propertyleri tutmaktadır.
3-Kullanılan Metotlar
InsertFirst: İlk elemanı eklemek için kullandığımız metottur.
InsertLast: Son elemanı eklemek için kullandığımız metottur.
EnYuksekPersonel: Girilen otel bilgisine göre otelin personel bilgisi bulunur ve en yüksek puanlı personel ekrana yazdırılır.
DeleteFirst: Linked listten ilk elemanı silmek için kullandığımız metottur.
DeleteLast: Linked listten son elemanı silmek için kullandığımız metottur.
DeletePosition: Linked listten istenilen pozisyondaki elemanı silmek için kullandığımız metottur.
GetElement: Gelen tc numarsına göre aranan eleman personel temp ile geri döndürülür.
Node Find: Tc’ye göre linked listten personel bilgisi bulma.
DugumSayisi: Ağacımızdaki düğüm sayısını hesaplar.
PreOrderInt: Kök-Sol-Sağ gezinmesi.
InOrderInt: Sol-Kök-Sağ gezinmesi.
PostOrderInt: Sol-Sağ-Kök gezinmesi.
Ziyaret: Gelen düğümdeki verilere erişme.
OtelIDAraInt: Otel ID sine göre ikili ağaç düğümünde oteli aramamızı sağlar.
OtelEkle: Gelen değere göre uygun düğüme otel ekleme.
Successor: Düğüm silerken, silinen düğüm yerine en uygun düğümü getirmek için kullanıldı.
OtelSil: Düğümlerden Otel silme işlemi.
Add: Otel bilgisi eklemek için gelen anahtarı hashaFonsiyonu na gönderir. Gelen indise göre otel bilgisi hash tablosuna ve heap ağacına kaydedilir.
hashFonksiyonu: String karakterlerin ASCII değerlerini toplayıp modunu alır ve geriye otel bilgisinin ekleneceği indisi döndürür.
OtelBilgiGuncelle: Gelen otel bilgisine göre heap içinde güncelleme yapar.
GetOtelBilgiPuan: Parametre olarak alınan anahtar değerine göre hash tablosuna yerleştirilir ve heap teki liste döndürülür.
GetOtelBilgiYıldız: Gelen anahtar ve yıldız sayısına göre hash tablosunda yeri bulunur. Heap teki liste döndürülür.
OtelPersonelEkle: Gelen düğümden otel ID sine göre linked listte teni personel ekleme.
DerinlikBulInt: Ağaç derinliği hesaplama.
InsertOtel: Otel bilgisini heap ağacına ekleriz.
IsEmpty: Heap in boş olup olmadığı kontrol edilir.
MoveToUpPuan: Eklenen yeni düğüm bir üst düğüm ile karşılaştırılarak uygun yere yerleştirilir.
RemoveMax: Maximum değeri silme.
MoveToDownPuan: Silinen elemandan sonra heap ağacını düzenler.
PuanaGoreListele: Otel bilgilerini puana göre listeleme.
YıldızaGöreAra: Otelleri yıldız sayısına göre arama yapmak için oluşturulmuş metot.
ElemanSil: Gelen parametreye göre heap içinde arama yapar ve bulunan indisteki otel bilgisini siler.

#6 Proje Youtube Linki  


#7 Proje GitHub Linki: https://github.com/mtsoydan/OtelOtomasyon

#8 Proje Gerçekleştiriminde Yararlanılan Kaynaklar
https://www.geeksforgeeks.org/
https://stackoverflow.com/


