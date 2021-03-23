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
   public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        //[SecuredOperation("rental.add,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Message.AddedRental);

        }

        [SecuredOperation("rental.delete,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.DeletedRental);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Rental>>(Message.CanNotListedRental);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Message.ListedRental);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("rental.update,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.UpdatedRental);
        }
    }
}
