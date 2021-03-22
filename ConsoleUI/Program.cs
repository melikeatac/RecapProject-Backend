using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllColorTest();
            //GetAllBrandTest();
            //GetAllCarTest();
            //GetCarDetailsTest();
            //GetCustomerDetailsTest();
            //GetUserDetailsTest();
            //AddRental();
            //AddCustomer();

        }

        private static void GetCustomerDetailsTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetails();
            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CustomerId + "  /  " + customer.CompanyName + "  /  " +
                        customer.UserId + "  /  " + customer.RentDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { CustomerId = 7, UserId = 3, CompanyName = "KOLAYYAZILIM" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { RentalId = 1, RentDate = "04.05.2020", ReturnDate = "14.05.2020", CarId = 1, CustomerId = 2 });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("BrandID:  " + brand.BrandId + "BrandName:  " + brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "  /  " + car.Description + "  /  " +
                        car.DailyPrice + "  /  " + car.BrandName + "  /  " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void GetAllCarTest()
        {
            CarManager carManager= new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("CarId: " + car.CarId + " " + "BrandId: " + car.BrandId
                    + " " + "ColorId: " + car.ColorId + " " + "CarYear: " + car.CarYear
                    + " " + "CarDescription " + car.Description + " " + "CarDailyPrice:" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("ColorId: " + color.ColorId + " " + "ColorName: " + color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
