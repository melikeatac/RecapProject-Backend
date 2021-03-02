using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>/*Bir tane Tablo ver,bir tane de context tipi ver anlamına gelir.*/
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            /*Using içerisine yazılan nesneler using bitince
             garbage collectora gelir ve bellekten atılır.Çünkü context işlemi pahalı bir işlem.
            Doğrudan buraya NorthwindContext context= new NoerthwindContext(); de yazılabilirdi ancak
            bu şekilde daha performanslı bir ürün geliştirilmiş olur.
            */
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakala, eklenecek datayı bul.
                addedEntity.State = EntityState.Added;//yakalanan referans aslında eklenecek bir nesne
                context.SaveChanges();//yukarıdaki ekleme işlemini gerçekleştirir
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//referansı yakala,silinecek datayı bul
                deletedEntity.State = EntityState.Deleted;//yakalanan referans aslında silinen bir nesne
                context.SaveChanges();//yukarıdaki ekleme işlemini gerçekleştirir
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        //Filtre verilebilirde verilmeyebilir de...
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            /*Filtre gönderilmediyse veri tabanındaki tüm datayı getir.
             Ama filtre verdiyse onu uygula ve datayı listele*/

            using (TContext context = new TContext())
            {
                /*Ternary operatörü kullanıldı.
                 Filtre null sa :'nın sol kısmı çalışır
                 Filtre null değilse :'nın sağ tarafı çalışır.*/
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//referansı yakala, veritabanındaki datayı bul.
                updatedEntity.State = EntityState.Modified;//yakalanan referans aslında güncellenen bir nesne
                context.SaveChanges();//yukarıdaki ekleme işlemini gerçekleştirir
            }
        }
    }
}
