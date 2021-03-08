using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length <1 )
            {
                return new ErrorResult(Message.CanNotBeAddedCustomer);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Message.AddedCustomer);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Message.DeletedCustomer);
        }

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

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Message.UpdatedCustomer);
        }
    }
}
