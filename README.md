
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

``` 
![Uygulama Ekran Görüntüsü](data:image/png;base64,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)
```
    
