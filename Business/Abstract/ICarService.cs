using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Business katmanının Car nesnesiyle iligli interface i yazıldı
    public interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        List<Car> GetById(int id);
        void Update(Car car);

    }
}
