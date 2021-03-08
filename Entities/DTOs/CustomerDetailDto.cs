using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string RentDate { get; set; }
    }
}
