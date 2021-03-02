using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()//CUNSTRUCTOR'dır.Bellekte referans aldığı zaman çalışacak kısım.
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,CarYear=2021,Description="2021 model araba",DailyPrice=5000},
                new Car{CarId=2,BrandId=2,ColorId=2,CarYear=2020,Description="2020 model araba",DailyPrice=3000},
                new Car{CarId=3,BrandId=3,ColorId=3,CarYear=2021,Description="2021 model araba",DailyPrice=8000},
                new Car{CarId=4,BrandId=4,ColorId=4,CarYear=2017,Description="2017 model araba",DailyPrice=1000},
                new Car{CarId=5,BrandId=5,ColorId=5,CarYear=2019,Description="2019 model araba",DailyPrice=2000},
            };
        }
        public void Add(Car car)
        {/*Arabaları veri kaynağına ekleriz.Şu an InMemory çalışıldığı için listeye ekleme yapılır.*/
            _cars.Add(car);
        }
        public void Delete(Car car)
        {//Aşağıdaki işlemde de foreach döngüsündeki gibi tüm elemanları tek tek dolaşıyor.
            Car carToDelete = _cars.SingleOrDefault(p => p.BrandId == car.BrandId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;//Veri tabanını olduğu gibi döndürüyoruz...
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int BrandId)
        {
            /*where koşulu,içinde şarta uyan tüm elemanları yeni bir liste haline getirir ve onu döndürür.
             İstenilen sayıda yeni koşul eklenebilir.
             */
            return _cars.Where(p => p.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.BrandId == car.BrandId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarYear = car.CarYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;

        }
    }
}
