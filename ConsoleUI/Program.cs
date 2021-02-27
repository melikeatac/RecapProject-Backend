using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("CarId: " + car.CarId + " " + "BrandId: " + car.BrandId
                    + " " + "ColorId: " + car.ColorId + " " + "CarYear: " + car.CarYear
                    + " " + "CarDescription " + car.Description + " " + "CarDailyPrice:" + car.DailyPrice);
            }
            Console.WriteLine("********************************************************************");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("*********************************************************************");
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
