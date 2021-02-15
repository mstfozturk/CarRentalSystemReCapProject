using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Business katmanının Car nesnesiyle iligli interface i yazıldı
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IResult Update(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();


    }
}
