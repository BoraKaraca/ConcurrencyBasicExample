
# .Net Core Conccurency Basit Örnek Uygulaması

.Net Core Razor Page kullanılarak basit bir şekilde Optimistic Concurrency(İyimser Eş Zamanlılık) konusunda uygulanan yöntemlerin ve farkılıkların incelenmesi için yapılmıştır.

Bu uygulamada sadece Update işlemleri için eş zamanlılık kontrolü bulunmaktadır. Bunun için 2 farklı yöntem kullanılmıştır. Attribute olarak Propertye tanımlanması ve RowVersion olarak yeni bir sütun aracılığıyla kontrol sağlanması ve ayrıca normal update işlemi yapılarak concurrency olmadan yapılan update işleminde Last In Wins konusu örneklendirilmiştir.




## ConcurrencyCheckAttributeToken olarak eklenmesi

    public class ConcurrencyCheckAttributeToken
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
    
## ConcurrencyRowVersion olarak eklenmesi
    public class ConcurrencyRowVersion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }


  
## Localde Çalıştırılması 

appsettings.json içerisindeki ConnectionStrings kontrol edilerek düzenlendikten sonra Package Manager Console' 
Default project Infrastructure seçilip update-database yazıldıktan sonra uygulama çalıştırılabilir.

![PackageManagerScreenShot](https://github.com/BoraKaraca/ConcurrencyBasicExample/blob/main/screenShot.png?raw=true)
