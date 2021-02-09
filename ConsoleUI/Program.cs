using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            
            //Tüm araçların listesini yazdırıyoruz
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model "+ car.Description +" : "+ car.DailyPrice+"TL");
            }
            Console.WriteLine("------------------");

            //Araç ekleiyoruz ve ekleme işleminden sonra tüm araçların listesini yazdırıyoruz
            Car car1 = new Car() { Id = 1, BrandId = 4, ColorId = 3, ModelYear = 2020, DailyPrice = 700, Description = "BMW X5 Dizel Otomatik" };
            carManager.Add(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model "+ car.Description + " : " + car.DailyPrice+"TL");
            }
            Console.WriteLine("------------------");

            //Araç düzenliyoruz ve düzenleme işleminden sonra tüm araçların listesini yazdırıyoruz
            Car car2 = new Car() { Id = 1, BrandId = 1, ColorId = 2, ModelYear = 2015, DailyPrice = 280, Description = "Opel Astra Benzinli Manuel" };
            carManager.Update(car2);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model " + car.Description + " : " + car.DailyPrice + "TL");
            }
            Console.WriteLine("------------------");

            //Araç Silme işleminden sonra tüm araçların listesini yazdırıyoruz
            carManager.Delete(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model " + car.Description + " : " + car.DailyPrice + "TL");
            }
            Console.WriteLine("------------------");
            //Araçları id numarasına göre yazdırıyoruz
            carManager.GetById(2);
        }
    }
}
