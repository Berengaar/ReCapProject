# ReCapProject

13.gün ödevi Araştırmalar

1-) Controller => Kullanıcıdan gelen istekleri anlayan ve işleyen sınıflardır

2-) Route => Gerekli controller sınıfına yönlendirme yapar.

3-) Action sınıfı : 

  Son kullanıcıdan gelen istek doğrultusunda hangi işlemin yapılacağını,
  belirtilen controller sınıfında yer alan metodlar, yani action ‘lar yapmaktadır. 
  Action özellikle daha özelleştirilmiş kullanıma odaklandığı için benzer metot isimleri ile 
  birden fazla işlem yapılması çalışma zamanında sorunlara sebep olabilmektedir.Bu yüzden 
  action metottlar overload kullanımlar için uygun değillerdir.
  
  4-) ActionResult sınıfı :
  
  Controller üzerinde kullanılan action'ların, action result ile geri dönüşleri vardır
  Yani geri dönüş tipi olan action da denilebilir
  
  5-) Model Bağlama :

     - Veri yolu, form alanları ve sorgu dizeleri gibi çeşitli kaynaklardan veri alır.
     - RazorYöntem parametreleri ve ortak özellikler içindeki denetleyicilere ve sayfalara verileri sağlar.
     - Dize verilerini .NET türlerine dönüştürür.
    => Çünkü bu işlem model bağlama olmadan kod yazarak hem uzun hem de hatalı olabilmektedir
    
    !! Varsayılan olarak, model bağlama, bir HTTP isteğindeki aşağıdaki kaynaklardan gelen 
       anahtar-değer çiftleri biçimindeki verileri alır:
       
       1-) Form alanları
       2-) İstek gövdesi ( [ApiController] özniteliğine(attribute) sahip denetleyiciler için.)
       3-) Veri yönlendirme
       4-) Sorgu dizesi parametreleri
       5-) Karşıya yüklenen dosyalar
       
       Varsayılan kaynak doğru değilse yada manuel olarak seçilcekse, kaynağı belirtmek için aşağıdaki özniteliklerden birini kullanmalıyız:
       
       [FromQuery]  => Sorgu dizesinden değerleri alır.
       [FromRoute]  => Rota verilerinden değerleri alır.
       [FromForm]   => Postalanan form alanlarındaki değerleri alır.
       [FromBody]   => İstek gövdesinden değerleri alır.
       [FromHeader] => HTTP başlıklarındaki değerleri alır.
       
       => Bu öznitelikler(Attribute), model özelliklerine(metotlar, prepertyler, field'lar) tek tek eklenir.
       Direkt olarak class'a eklenmemelidir.
