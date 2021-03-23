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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("color.add,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
            if (color.ColorName.Length<2)
            {
                return new ErrorResult(Message.CanNotBeAddedColor);
            }
            _colorDal.Add(color);
            return new SuccessResult(Message.AddedColor);
        }

        [SecuredOperation("color.delete,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Message.DeletedColor);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Color>>(Message.CanNotListedColor);
            }
           return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Message.ListedColor);
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("color.update,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Message.UpdatedColor);
        }
    }
}
