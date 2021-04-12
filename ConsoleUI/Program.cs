using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            // CRUDtest(carManager, brandManager);
            //GetAllCars();
            //GetCarsByBrandIdTest();
            //GetCarsByColorIdTest();

        }

        private static void GetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.ColorId);
            }
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var id in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(id.CarId + " " + id.BrandId + " " + id.DailyPrice);
            }
        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " " + car.DailyPrice);
            }
        }

        private static void CRUDtest(CarManager carManager, BrandManager brandManager)
        {
            carManager.Add(new Car { CarId = 6, BrandId = 2, ColorId = 3, ModelYear = 2002, DailyPrice = 600, Description = "KIZILCAHAMAM NAKLİYAT" });

            carManager.Update(new Car { CarId = 1, ColorId = 3, ModelYear =2002, BrandId = 2, DailyPrice = 900, Description = "TWEEN Collections" });
            brandManager.Add(new Brand { BrandId = 4, BrandName = "HONDA" });
            brandManager.Delete(new Brand { BrandId = 4 });
            brandManager.Update(new Brand { BrandId = 1, BrandName = "TOYOTA" });


            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
