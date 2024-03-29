﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto { Id = c.Id, BrandName = b.BrandName, ColorName = co.ColorName, Description = c.Description, DailyPrice = c.DailyPrice, ImagePath=ci.ImagePath, CarImageDate=ci.CarImageDate };
                return result.ToList();
            }
        }
    }
}
