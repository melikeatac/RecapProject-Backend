using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("brand.add,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Message.CanNotBeAddedBrand);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Message.AddedBrand);
        }

        [SecuredOperation("brand.delete,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.DeletedBrand);
        }

        [CacheAspect]
        public IDataResult<List<Brand>>GetAll()
        {
            if (DateTime.Now.Hour==2)
            {
                return new ErrorDataResult<List<Brand>>(Message.CanNotListedBrand);

            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Message.ListedBrand);
        }

        [SecuredOperation("brand.update,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Message.UpdatedBrand);
        }
    }
}
