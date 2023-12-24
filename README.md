# Advert REST API

Bu proje, ara� ilanlar�n� listeleyen ve detaylar�n� getiren bir REST API'yi i�erir.

## Proje Yap�s�

- **/Controllers**: Controller kodlar�n� i�erir.
- **/Models**: Model dosyalar�n� i�erir.
- **/Repositories**: Repository'i i�erir.
- **/Services**: Service s�n�f�n� i�erir.
- **/appsettings.Development**: Config ve veritaban� bilgilerini i�erir.
- **/Dockerfile**: Docker komutlar�n� i�erir.
- **/docker-compose.yml**: docker i�in proje ve veritaban� bilgilerini bar�nd�ran kodlar� i�erir.

## Teknolojiler ve Kullan�lan Ara�lar

- **.NET 7**: API geli�tirmek i�in kullan�ld�.
- **Dapper**: Micro ORM olarak kullan�ld�.
- **MSSQL**: Veritaban� olarak kullan�ld�.
- **Docker**: Projeyi konteynerize etmek i�in kullan�ld�.

## Ba�lang��

Projenin �al��t�r�lmas� i�in a�a��daki ad�mlar� izleyin:

NOT: Docker i�in gerekli ayarlamalar yap�lm�� olmas�na ra�men, �irket bilgisayar�mda Docker Desktop kuramad���m i�in testleri yap�lamam��t�r.

0. docker-compose projede yer almaktad�r. Onun ile projeyi �al��t�rmay� deneyebilirsiniz.(Ben yukar�da belirtti�im sebepten dolay� test edemedim)
1. Projeyi Visual Studio ile �al��t�r�n.
2. Proje i�in belirtmi� oldu�unuz veritaban� sizde aktif ise, proje aya�a kalkacak ve istek g�nderebileceksiniz.
3. Veritaban� ba�lant� c�mlesi : "Server=localhost\\SQLEXPRESS;Database=LocalMyDB;Trusted_Connection=True;" �eklindedir.

## API Endpoints

### 1. T�m �lanlar� Getir
    URL: '/Advert/all'
    HTTP Method: GET
    Query Parametreleri:
        'CategoryId'
        'Price'
        'Gear'
        'Fuel'
        'Page'
    �rnek Kullan�m: /Advert/all?CategoryId=347&Price=200000&Gear=D�z&Fuel=Dizel&Page=1
    
### 2. �lan Detay�n� Getir
    URL: '/Advert/get'
    HTTP Method: GET
    Query Parametreleri:
        'Id'
    �rnek Kullan�m: /Advert/get?id=16165145
### 3. Ziyaret Kayd� Ekle
    URL: '/Advert/visit'
    HTTP Method: POST
    Request Body:
        {
            "advertId": "123456"
        }
    �rnek Kullan�m: /Advert/all?CategoryId=347&Price=200000&Gear=D�z&Fuel=Dizel&Page=1
    
## HTTP Response Codes

- **'200'**: Ba�ar�l� i�lem.
- **'204'**: �lan bulunamad�.
- **'500'**: ��sel hata olu�tu.


