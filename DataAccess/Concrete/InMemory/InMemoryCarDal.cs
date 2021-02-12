using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {

    }
    //public class InMemoryCarDal : ICarDal
    //{
    //    List<Car> _cars;

    //    //Datalar veritabanından geliyor gibi constructor ile simüle edildi.
    //    public InMemoryCarDal()
    //    {
    //        _cars = new List<Car>
    //        {
    //            new Car {Id=1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=200,Description="Opel Corsa Dizel Otomatik"},
    //            new Car {Id=2,BrandId=2,ColorId=2,ModelYear=2021,DailyPrice=600,Description="Wolksvagen Passat Dizel Otomatik"},
    //            new Car {Id=3,BrandId=3,ColorId=3,ModelYear=2015,DailyPrice=450,Description="Audi A3 Dizel Otomatik"},
    //        };
    //    }

    //    //İstenen operasyonlar yazıldı
    //    public void Add(Car car)
    //    {
    //        _cars.Add(car);
    //    }

    //    public void Delete(Car car)
    //    {
    //        Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
    //        _cars.Remove(carToDelete);
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _cars;
    //    }

    //    public List<Car> GetById(int id)
    //    {
    //        return _cars.Where(c => c.Id == id).ToList();
    //    }

    //    public void Update(Car car)
    //    {
    //        Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
    //        carToUpdate.BrandId = car.BrandId;
    //        carToUpdate.ColorId = car.ColorId;
    //        carToUpdate.ModelYear = car.ModelYear;
    //        carToUpdate.DailyPrice = car.DailyPrice;
    //        carToUpdate.Description = car.Description;
    //    }
    //}
}
