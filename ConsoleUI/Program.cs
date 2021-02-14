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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //CarDetails listeleme
            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetail.BrandName + " " + carDetail.Description + " " + carDetail.ColorName + " ==> " + carDetail.DailyPrice);
            }
            Console.WriteLine("------------------");
            //Tüm araçların listesini yazdırıyoruz
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model " + car.Description + " : " + car.DailyPrice + "TL");
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
            //Marka listeleme ekleme, güncelleme ve silme
            Console.WriteLine("------------------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            brandManager.Update(new Brand { BrandId = 4, BrandName = "Renault" });

            brandManager.Add(new Brand { BrandName = "BMW" });
            brandManager.Delete(new Brand { BrandId = 4 });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            //Renk listeleme, ekleme, güncelleme ve silme
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            colorManager.Add(new Color { ColorName = "Sarı" });
            colorManager.Update(new Color { ColorId = 1, ColorName = "Kırmızı" });
            colorManager.Delete(new Color { ColorId = 1002 });


            //araç ekleme
            carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = 2019, DailyPrice = 520, Description = "Golf Dizel Otomatik" });

            //araç Güncelleme
            carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 250, Description = "Corsa Dizel Otomatik" });
            //araç silme
            carManager.Delete(new Car { Id = 1006 });

            //CarDetails listeleme
            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetail.BrandName + " " + carDetail.Description + " " + carDetail.ColorName + " ==> " + carDetail.DailyPrice);
            }

        }
    }
}
