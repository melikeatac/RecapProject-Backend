using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        //İş katmanında kullanılacak servis katmanı
        List<Car> GetAll();//Tüm ürünleri listeletecek bir ortam
    }
}
