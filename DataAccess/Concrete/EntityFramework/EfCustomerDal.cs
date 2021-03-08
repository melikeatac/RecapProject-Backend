using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.UserId
                             join r in context.Rentals
                             on c.CustomerId equals r.CustomerId


                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 UserId = u.UserId,
                                 CompanyName = c.CompanyName,
                                 RentDate = r.RentDate
                                 

                             };
                             return result.ToList();
            }
        }
    }
}
