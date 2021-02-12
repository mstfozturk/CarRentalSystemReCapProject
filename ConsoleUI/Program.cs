using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            //Tüm araçların listesini yazdırıyoruz
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model "+ car.Description +" : "+ car.DailyPrice+"TL");
            }
            Console.WriteLine("------------------");

            //BrandId ye göre araç listeleme

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("------------------------");

            //ColorId ye göre araç listeleme
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
