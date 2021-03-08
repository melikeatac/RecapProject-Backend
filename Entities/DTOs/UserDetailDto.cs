using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserDetailDto:IDto
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public int RentalId { get; set; }
        public String RentDate { get; set; }

    }
}
