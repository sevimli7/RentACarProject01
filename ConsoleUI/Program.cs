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
            BrandManager brandManager = new BrandManager(new InMemoryCarDal());
            ColorManager colorManager = new ColorManager(new InMemoryCarDal());
            carManager.Add(new Car { CarId=6, BrandId=2, ColorId=3, ModelYear=2002,DailyPrice=600, Description="KIZILCAHAMAM NAKLİYAT"});
            carManager.Update(new Car { CarId=1, ColorId=3, ModelYear=2002, BrandId=2, DailyPrice=900, Description="TWEEN Collections"});
            brandManager.Add(new Brand{BrandId=4, BrandName="HONDA" });
            brandManager.Delete(new Brand{ BrandId=4});
            brandManager.Update(new Brand { BrandId = 1, BrandName = "TOYOTA" });
            
            
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
