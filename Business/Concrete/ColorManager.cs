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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length<2)
            {
                return new ErrorResult(Message.CanNotBeAddedColor);
            }
            _colorDal.Add(color);
            return new SuccessResult(Message.AddedColor);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Message.DeletedColor);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Color>>(Message.CanNotListedColor);
            }
           return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Message.ListedColor);
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Message.UpdatedColor);
        }
    }
}
