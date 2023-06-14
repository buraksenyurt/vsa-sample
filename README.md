# Uygulamalı Vertical Slice Architecture Deneyi

Bu proje .net tabanlı bir Vertical Slice Architecture uyarlamasıdır. Amacım uygulamalı olarak söz konusu mimarinin nasıl uygulandığını anlamaya çalışmak.

## Sistem ve Kurgu

Çözümü moon isimli Ubuntu 22.04 tabanlı sistemimde yapıyorum. Sistemde .Net 7 sürümü yüklü. Solution MovieApp isimli boş bir web projesi içermekte. VSA ilkeleri gereği ihtiyaçların tamamı buradaki klasörlerde yer alıyor. VSA'nın ana omurgasını oluşturan özellik setleri de Features isimli klasörde yer almakta. Örnekte çok basit bir film arşivi ele alınmakta. Kategori bazlı filmlerin tutulduğu bir çözüm olarak düşünebiliriz.

## Proje Bağımlılıkları

Çözümde nesneler arası map işlemleri için AutoMapper, komut ve sorguların ayrılmasında CQRS deseni ve onu yönetecek olan MediatR ile Postgresql veri tabanı kullanılıyor. Her zaman olduğu gibi postgresql'i docker container olarak kullanmayı tercih edeceğim.

```bash
# postgresql docker container'ını yüklemek için
sudo docker run --name moviesdb -e POSTGRES_USER=scoth -e POSTGRES_PASSWORD=tiger -p 5435:5432 -v /data:/var/lib/postgresql/data -d postgres

# Migration için EF tool'a ihtiyacımız olacaktır
dotnet tool install -g dotnet-ef

# Migration planı oluşturup çalıştırmak için
dotnet ef migrations add InitialCreate
dotnet ef database update

# Proje için gerekli nuget paketlerinin yüklenmesi
cd MovieApp

dotnet add package Microsoft.EntityFrameworkCore 
dotnet add package Microsoft.EntityFrameworkCore.Design 
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL 
dotnet add package AutoMapper 
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection 
dotnet add package MediatR 
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection 
dotnet add package Swashbuckle.AspNetCore
```