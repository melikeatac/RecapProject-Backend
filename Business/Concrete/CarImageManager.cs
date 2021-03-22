using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carimageDal)
        {
            _carImageDal = carimageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.AddFile(file);

            _carImageDal.Add(carImage);

            return new SuccessResult(Message.CarImageAdded);
        }


        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);

            if (image == null)
            {
                return new ErrorResult(Message.CarImageNotFound);
            }

            FileHelper.DeleteFile(image.ImagePath);

            _carImageDal.Delete(carImage);

            return new SuccessResult(Message.CarImageDeleted);
        }
        
        
        
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldImage = _carImageDal.Get(c => c.Id == carImage.Id);

            if (oldImage == null)
            {
                return new ErrorResult(Message.CarImageNotFound);
            }
            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.UpdateFile(file, oldImage.ImagePath);
            _carImageDal.Update(carImage);

            return new SuccessResult(Message.CarImageUpdated);
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Message.CarImageListed);
        }
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == carImageId));
        }
        // Business Rules Methods
        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carId).Count >= 5)
            {
                return new ErrorResult(Message.CarImageNumberError);
            }
            return new SuccessResult();
        }


    }
}