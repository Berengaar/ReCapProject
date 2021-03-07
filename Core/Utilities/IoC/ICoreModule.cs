using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //Tüm projelerimizde kullanacağımız yapı
    //Genel bir bağımlılık oluşturmak için
    //Farklı bir projede farklı bir veri tabanında kullanım için 
    //Modülleri tek tek refaktör etmek yerine böyle bir genel interface hazırlarız
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);        //Genel bağımlılıkları yüklicek       Servisleri yüklüycek(module)
    }
}
