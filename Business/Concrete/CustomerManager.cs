using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("customer.add,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length <1 )
            {
                return new ErrorResult(Message.CanNotBeAddedCustomer);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Message.AddedCustomer);
        }

        [SecuredOperation("customer.delete,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Message.DeletedCustomer);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Customer>>(Message.CanNotListedCustomer);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Message.ListedCustomer);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Message.DetailsCustomer);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("customer.update,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Message.UpdatedCustomer);
        }
    }
}
