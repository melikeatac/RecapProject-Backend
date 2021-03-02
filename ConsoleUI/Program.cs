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
            Car car1 = new Car() { CarId = 8, CarYear = 2000, DailyPrice = 40, Description = "2000 model car", BrandId = 1, ColorId = 2 };
            CarManager carManager = new CarManager(new EfCarDal());
            //GetAllTest(carManager);
            //GetCarsByBrandIdTest(carManager);
            //GetCarsByColorIdTest(carManager);
            //carManager.Add(car1);
            //carManager.Delete(car1);
            //GetDetailsTest(carManager);

        }

        private static void GetDetailsTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + "  /  " + car.Description + "  /  " +
                    car.DailyPrice + "  /  " + car.BrandName + "  /  " + car.ColorName);
            }
        }

        private static void GetAllTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("CarId: " + car.CarId + " " + "BrandId: " + car.BrandId
                    + " " + "ColorId: " + car.ColorId + " " + "CarYear: " + car.CarYear
                    + " " + "CarDescription " + car.Description + " " + "CarDailyPrice:" + car.DailyPrice);
            }
        }

        private static void GetCarsByColorIdTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetCarsByBrandIdTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
