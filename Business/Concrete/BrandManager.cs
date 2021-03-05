using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Message.CanNotBeAddedBrand);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Message.AddedBrand);
        }
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.DeletedBrand);
        }

        public IDataResult<List<Brand>>GetAll()
        {
            if (DateTime.Now.Hour==2)
            {
                return new ErrorDataResult<List<Brand>>(Message.CanNotListedBrand);

            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Message.ListedBrand);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Message.UpdatedBrand);
        }
    }
}
