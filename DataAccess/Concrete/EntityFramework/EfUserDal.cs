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
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                             join b in context.Rentals
                             on c.CustomerId equals b.CustomerId
                             join a in context.Users
                             on c.UserId equals a.UserId
                             select new UserDetailDto
                             {
                                 UserId = a.UserId,
                                 UserFirstName = a.FirstName,
                                 UserLastName = a.LastName,
                                 RentalId = b.RentalId,
                                 RentDate = b.RentDate,
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName

                             };
                return result.ToList();
            }
        }
    }
}
