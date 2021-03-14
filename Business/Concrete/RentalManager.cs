﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public IResult Add(Rental rental)
        {

            if (rental.ReturnDate == null && _rentalDal.GetAll(rd => rd.CarId == rental.CarId).Count > 0)
            {
                Console.WriteLine(_rentalDal.GetRentalDetails(rd => rd.CarId == rental.CarId).Count);
                return new ErrorResult(Messages.OnRental);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(I => I.Id == id));
        }

        public IResult Return(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId).LastOrDefault();
            if (result.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalAlreadyReturned);
            }
            else
            {
                result.ReturnDate = DateTime.Now;
                _rentalDal.Update(result);
                return new SuccessResult(Messages.RentalReturned);
            }
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
