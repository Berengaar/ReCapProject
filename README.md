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
       
       - Form alanları
       - İstek gövdesi ( [ApiController] özniteliğine(attribute) sahip denetleyiciler için.)
       - Veri yönlendirme
       - Sorgu dizesi parametreleri
       - Karşıya yüklenen dosyalar
       
       Varsayılan kaynak doğru değilse yada manuel olarak seçilcekse, kaynağı belirtmek için aşağıdaki özniteliklerden birini kullanmalıyız:
       
       [FromQuery]  => Sorgu dizesinden değerleri alır.
       [FromRoute]  => Rota verilerinden değerleri alır.
       [FromForm]   => Postalanan form alanlarındaki değerleri alır.
       [FromBody]   => İstek gövdesinden değerleri alır.
       [FromHeader] => HTTP başlıklarındaki değerleri alır.
       
       => Bu öznitelikler(Attribute), model özelliklerine(metotlar, prepertyler, field'lar) tek tek eklenir.
       Direkt olarak class'a eklenmemelidir.
       
6-)Adım adım dosya İşlemleri : 

=> Öncelikle Dosya yolu için Business/Constants içinde FilePath isimli bir class oluşturur ve ona "@" yardımıyla default bir yol atarız.
Not: Daha sonrasında bu yolu başka bir class içinde değiştiricez.

=> 2.adımda Core katmanında utilities klasörümüzde FileOperations dosyasını oluşturup içine Operations isminde bir class tanımlarız.
Dosyalamada 2 işlem mevcuttur.1 işlem dosyayı yazma, 2. işlemse dosyayı silmedir.

Dosya Kütüphaneleri :

1-) Microsoft.AspNetCore.Http => HTTP isteklerini ve yanıtlarını işlemek için türler içerir.
    IFormFile : HttpRequest ile gönderilen bir dosyayı temsil eder.

2-)System.IO => Dosyaların ve veri akışlarının okunmasına ve yazılmasına izin veren türleri ve temel dosya ve Dizin desteğini sağlayan türleri içerir.

   -Path.Combine()   : Dizeleri bir yol olarak birleştirir.
   
     -FileStream     : Belirtilen kaynak dosyalar üzerinde okuma, yazma, atlama gibi
     operasyonları yapmamıza yardımcı olan bir sınıftır.Bu sınıf sayesinde senkron
     ve asenkron olarak okuma/yazma operasyonları gerçekleştirilir. Sınıf olduğu için new
     ile çağrılır
     
     
     Not => Asenkron okuma yavaş çalışan işlemlerde birden fazla işlemin gerçekleimesini ve yavaş çalışan kodun işlemi 
     durdurmasını önler.Performansı arttırır.
     
     -FileMode.Create : İşletim sisteminin yeni bir dosya oluşturması gerektiğini belirtir.
      Dosya zaten varsa üzerine yazılır. Bunun için Write izin gerekir.


7-) GUID Sınıfı : 

=> GUID .Net bizim için rastgele 32 karakterlik bir string oluşturan sınıftır.  
Guid, benzersiz değerler oluşturmak için kullanılmaktadır.
Veritabanlarında id yerine kullanılabilir.(Benzersiz değer)
Örnek olarak ortak bir alana birden fazla kullanıcının dosya kaydetmesini gösterebiliriz. 
İki farklı kullanıcı aynı isimde dosya oluşturabilir ve bir kullanıcı 
diğer bir kullanıcının dosyasını bu şekilde ezebilir. 
Guid yapısı ise bize benzersiz değerler üretir ve böyle bir durumun oluşmamasını sağlar



