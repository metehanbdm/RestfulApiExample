# Advert REST API

Bu proje, araç ilanlarýný listeleyen ve detaylarýný getiren bir REST API'yi içerir.

## Proje Yapýsý

- **/Controllers**: Controller kodlarýný içerir.
- **/Models**: Model dosyalarýný içerir.
- **/Repositories**: Repository'i içerir.
- **/Services**: Service sýnýfýný içerir.
- **/appsettings.Development**: Config ve veritabaný bilgilerini içerir.
- **/Dockerfile**: Docker komutlarýný içerir.
- **/docker-compose.yml**: docker için proje ve veritabaný bilgilerini barýndýran kodlarý içerir.

## Teknolojiler ve Kullanýlan Araçlar

- **.NET 7**: API geliþtirmek için kullanýldý.
- **Dapper**: Micro ORM olarak kullanýldý.
- **MSSQL**: Veritabaný olarak kullanýldý.
- **Docker**: Projeyi konteynerize etmek için kullanýldý.

## Baþlangýç

Projenin çalýþtýrýlmasý için aþaðýdaki adýmlarý izleyin:

NOT: Docker için gerekli ayarlamalar yapýlmýþ olmasýna raðmen, þirket bilgisayarýmda Docker Desktop kuramadýðým için testleri yapýlamamýþtýr.

0. docker-compose projede yer almaktadýr. Onun ile projeyi çalýþtýrmayý deneyebilirsiniz.(Ben yukarýda belirttiðim sebepten dolayý test edemedim)
1. Projeyi Visual Studio ile çalýþtýrýn.
2. Proje için belirtmiþ olduðunuz veritabaný sizde aktif ise, proje ayaða kalkacak ve istek gönderebileceksiniz.
3. Veritabaný baðlantý cümlesi : "Server=localhost\\SQLEXPRESS;Database=LocalMyDB;Trusted_Connection=True;" þeklindedir.

## API Endpoints

### 1. Tüm Ýlanlarý Getir
    URL: '/Advert/all'
    HTTP Method: GET
    Query Parametreleri:
        'CategoryId'
        'Price'
        'Gear'
        'Fuel'
        'Page'
    Örnek Kullaným: /Advert/all?CategoryId=347&Price=200000&Gear=Düz&Fuel=Dizel&Page=1
    
### 2. Ýlan Detayýný Getir
    URL: '/Advert/get'
    HTTP Method: GET
    Query Parametreleri:
        'Id'
    Örnek Kullaným: /Advert/get?id=16165145
### 3. Ziyaret Kaydý Ekle
    URL: '/Advert/visit'
    HTTP Method: POST
    Request Body:
        {
            "advertId": "123456"
        }
    Örnek Kullaným: /Advert/all?CategoryId=347&Price=200000&Gear=Düz&Fuel=Dizel&Page=1
    
## HTTP Response Codes

- **'200'**: Baþarýlý iþlem.
- **'204'**: Ýlan bulunamadý.
- **'500'**: Ýçsel hata oluþtu.


