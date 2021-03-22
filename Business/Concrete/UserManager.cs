using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Message.CanNotBeAddedUser);
            }
            _userDal.Add(user);
            return new SuccessResult(Message.AddedUser);
        }
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Message.DeletedUser);
        }
        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour==7)
            {
                return new ErrorDataResult<List<User>>(Message.CanNotListedUser);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Message.ListedUser);
        }     

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Message.UpdatedUser); 
        }
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
