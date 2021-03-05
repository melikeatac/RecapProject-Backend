using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity
        /*Product dersek product category dersek category gelmesi gerekiyor.
                                          İlerde başka bi isim dersek o gelmesi gerekir.*/
    {/*GetAll dediğimizde tüm datayı da getirebilir. Ancak bazen ürünlerin tamamı listelenmez.Filtreleme getirmek isteriz.
      
      T yazan kısma sadece Entities Concrete alanları gelebilir başka alanlar gelmemelidir...Bunun için filtreleme işlemi yapılır.Buna
      generic constraint denir. where T:class kısmı class:referans tip olmalıdır demektir.
      */
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//filter=null filtre vermeyebilirsin demektir.Ancak Get kısmında filtre zorunludur.
        T Get(Expression<Func<T, bool>> filter);//Tek bir data getirmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
