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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //CarDetails listeleme
            foreach (var carDetail in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(carDetail.BrandName + " " + carDetail.Description + " " + carDetail.ColorName + " ==> " + carDetail.DailyPrice);
            }
            Console.WriteLine("------------------");
            //Tüm araçların listesini yazdırıyoruz
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.ModelYear + " Model " + car.Description + " : " + car.DailyPrice + "TL");
            }
            Console.WriteLine("---------- " + carManager.GetAll().Message + " --------");

            //BrandId ye göre araç listeleme
            var carsByBrandId = carManager.GetCarsByBrandId(1);
            if (carsByBrandId.Success == true)
            {
                foreach (var car in carManager.GetCarsByBrandId(1).Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            else
            {
                Console.WriteLine(carsByBrandId.Message);
            }

            Console.WriteLine("------------------------");

            //ColorId ye göre araç listeleme
            var carsByColorId = carManager.GetCarsByColorId(2);
            if (carsByColorId.Success == true)
            {
                foreach (var car in carManager.GetCarsByColorId(2).Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            else
            {
                Console.WriteLine(carsByColorId.Message);
            }

            //Marka listeleme ekleme, güncelleme ve silme
            Console.WriteLine("------------------------");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
            brandManager.Update(new Brand { BrandId = 4, BrandName = "Renault" });

            brandManager.Add(new Brand { BrandName = "BMW" });
            brandManager.Delete(new Brand { BrandId = 4 });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            //Renk listeleme, ekleme, güncelleme ve silme
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
            colorManager.Add(new Color { ColorName = "Sarı" });
            colorManager.Update(new Color { ColorId = 1, ColorName = "Kırmızı" });
            colorManager.Delete(new Color { ColorId = 1002 });


            //araç ekleme
            carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = 2019, DailyPrice = 520, Description = "Golf Dizel Otomatik" });

            //araç Güncelleme
            carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 200, Description = "Corsa Benzinli Otomatik" });

            //araç silme
            carManager.Delete(new Car { Id = 1006 });

            //CarDetails listeleme
            var carDetails = carManager.GetCarDetails();
            if (carDetails.Success == true)
            {
                foreach (var carDetail in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(carDetail.BrandName + " " + carDetail.Description + " " + carDetail.ColorName + " ==> " + carDetail.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(carDetails.Message);
            }
            userManager.Add(new User { FirstName = "Serdar", LastName = "Bey", Email = "serdarbey@email.com", Password = "12345" });
            userManager.Add(new User { FirstName = "Mustafa", LastName = "Bey", Email = "mustafabey@email.com", Password = "54321" });
            userManager.Add(new User { FirstName = "Merve", LastName = "Ceylan", Email = "ceylanmerve@email.com", Password = "11111" });
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            userManager.Update(new User { UserId = 3, FirstName = "Merve", LastName = "Ceylan", Email = "ceylanmerve@email.com", Password = "00000" });
            customerManager.Add(new Customer { UserId = 2, CustomerName = "İpekyolu" });
            rentalManager.Return(2);
            rentalManager.Add(new Rental { CarId = 3, CustomerId = 3, RentDate = DateTime.Now, });
            rentalManager.Return(3);
            rentalManager.Return(4);


        }
    }
}
