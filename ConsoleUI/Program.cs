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

            ColorManager colorManager = new ColorManager(new EfColorDal());

            // CRUDtest(carManager, brandManager);
            //GetAllCars();
            //GetCarsByBrandIdTest();
            //GetCarsByColorIdTest();
            //AddMethodTest();
            //BrandListTest();
            //CarNameListTest();
            //CarDetailTest2();
            //AddNewCustomers();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rental = rentalManager.Add(new Rental { CarId = 2, CustomerId = 1, RentalDate = DateTime.Now });
            Console.WriteLine(rental.Message);

        }

        private static void AddNewCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "kodlama io." });
            foreach (var c in customerManager.GetAll().Data)
            {
                Console.WriteLine(c.CompanyName);
            }
        }

        private static void CarDetailTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " *** " + car.BrandName + " *** " + car.ColorName);
            }
        }

        private static void CarNameListTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " " + car.CarName + " " + car.DailyPrice);
            }
        }

        private static void BrandListTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 6, BrandName = "BMW" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void AddMethodTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { ColorId = 4, BrandId = 2, DailyPrice = 800, ModelYear = 2014, Description = "Bakımda" });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId);
            }
        }

        private static void GetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine(car.ColorId);
            }
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var id in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine(id.CarId + " " + id.BrandId + " " + id.DailyPrice);
            }
        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
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


            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
