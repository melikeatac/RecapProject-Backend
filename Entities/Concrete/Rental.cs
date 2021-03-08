using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public String RentDate { get; set; }
        public String ReturnDate { get; set; }

    }
}
