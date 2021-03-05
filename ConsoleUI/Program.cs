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
            //Car car1 = new Car() { CarId = 8, CarYear = 2000, DailyPrice = 40, Description = "2000 model car", BrandId = 1, ColorId = 2 };
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            GetAllCarTest(carManager);
            //carManager.Add(car1);
            //carManager.Delete(car1);
            GetDetailsTest();
            GetAllColorTest(colorManager);
            GetAllBrandTest(brandManager);
        }

        private static void GetAllBrandTest(BrandManager brandManager)
        {
            BrandManager brandManager1 = new BrandManager(new EfBrandDal());
            var result = brandManager1.GetAll();
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
        private static void GetAllCarTest(CarManager carManager)
        {
            CarManager carManager2 = new CarManager(new EfCarDal());
            var result = carManager2.GetAll();
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

        private static void GetAllColorTest(ColorManager colorManager)
        {
            ColorManager colorManager1 = new ColorManager(new EfColorDal());
            var result = colorManager1.GetAll();
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
