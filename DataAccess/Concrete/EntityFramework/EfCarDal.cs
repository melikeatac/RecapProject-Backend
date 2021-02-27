using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var addedEntity = context.Entry(entity);/*Veri kaynağından gönderilen Car'a bir tane nesne ile eşleştir. */
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedEntity = context.Entry(entity);/*Veri kaynağından gönderilen Car'a bir tane nesne ile eşleştir. */
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext context=new ReCapContext())
            {
              return context.Set<Car>().SingleOrDefault(filter);
            }
            
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return filter == null ?
                context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList() ;
            }
        }
        public void Update(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedEntity = context.Entry(entity);/*Veri kaynağından gönderilen Car'a bir tane nesne ile eşleştir. */
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
            throw new NotImplementedException();
        }
    }
}
