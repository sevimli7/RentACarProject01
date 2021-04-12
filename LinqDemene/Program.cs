using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemene
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car> {

                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2020, DailyPrice=500, Description="THY"},
                new Car{CarId=2, BrandId=2, ColorId=3, ModelYear=2021, DailyPrice=800, Description="SEVEN ELEKTRONİK"},
                new Car{CarId=3, BrandId=1, ColorId=2, ModelYear=2020, DailyPrice=400, Description="MANGO"},
                new Car{CarId=4, BrandId=3, ColorId=1, ModelYear=2023, DailyPrice=500, Description="ANKARA BELEDİYESİ"},
                new Car{CarId=5, BrandId=1, ColorId=3, ModelYear=2021, DailyPrice=400, Description="THY SÜPERMARKET"},

            };
            List<Brand> brands = new List<Brand> {

                new Brand{BrandId=1, BrandName="BMW"},
                new Brand{BrandId=2, BrandName="MERCEDES"},
                new Brand{BrandId=3, BrandName="PORSHE"},

            };
            List<Color> colors = new List<Color> {

                new Color{ColorId=1, ColorName="BEYAZ"},
                new Color{ColorId=2, ColorName="SİYAH"},
                new Color{ColorId=3, ColorName="KIRMIZI"},

            };

            //AnyTest(cars);
            //FindTest(cars);
            //FindAllTest(cars);
            //WhereTest(cars);
            //Dtojoin(cars, brands);

            var result = from c in cars
                         join co in colors on c.ColorId equals co.ColorId
                         select new CarDTO {  CarId=c.CarId, ColorName=co.ColorName};

            foreach (var carDto in result)
            {
                Console.WriteLine(carDto.CarId+" "+carDto.ColorName);
            }
        }

        private static void Dtojoin(List<Car> cars, List<Brand> brands)
        {
            var result = from c in cars
                         join b in brands
                         on c.BrandId equals b.BrandId
                         select new CarDTO { CarId = c.CarId, BrandName = b.BrandName };

            foreach (var carDTO in result)
            {
                Console.WriteLine(carDTO.CarId + " " + carDTO.BrandName);
            }
        }

        private static void WhereTest(List<Car> cars)
        {
            var result = cars.Where(p => p.Description.Contains("THY")).OrderBy(p => p.DailyPrice > 400);
            foreach (var car in result)
            {
                Console.WriteLine(car.CarId);
            }
        }

        private static void FindAllTest(List<Car> cars)
        {
            var result = cars.FindAll(p => p.DailyPrice == 500);
            foreach (var car in result)
            {
                Console.WriteLine(car.CarId);
            }
        }

        private static void FindTest(List<Car> cars)
        {
            var result = cars.Find(p => p.DailyPrice == 500);
            Console.WriteLine(result.DailyPrice);
        }

        private static void AnyTest(List<Car> cars)
        {
            var result = cars.Any(p => p.CarId == 7);//listede aradığımız Id de eleman olup olmadığını bool olarak kontrol eder.
            Console.WriteLine(result);
        }
        class CarDTO
        {
            public int CarId { get; set; }
            public string BrandName { get; set; }
            public string ColorName { get; set; }
        }
    }
}
