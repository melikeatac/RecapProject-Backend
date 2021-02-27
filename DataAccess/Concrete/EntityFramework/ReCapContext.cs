using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context nesnesi Db tabloları ile proje classlarını ilişkilendirir.
    class ReCapContext:DbContext
    {
        //Bu metod projenin hangi veritabanıyla ilişkili olduğunu göstermek amacıyla kullanılır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCap;Trusted_Connection=true");

        }
        //veri tabanındaki hangi nesne,projedeki hangi nesneye karşılık gelecek?
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
