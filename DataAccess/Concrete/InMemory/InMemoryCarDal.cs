using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal,IBrandDal,IColorDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2020, DailyPrice=500, Description="THY"},
                new Car{CarId=2, BrandId=2, ColorId=3, ModelYear=2021, DailyPrice=800, Description="SEVEN ELEKTRONİK"},
                new Car{CarId=3, BrandId=1, ColorId=2, ModelYear=2020, DailyPrice=400, Description="MANGO"},
                new Car{CarId=4, BrandId=3, ColorId=1, ModelYear=2023, DailyPrice=400, Description="ANKARA BELEDİYESİ"},
                new Car{CarId=5, BrandId=1, ColorId=3, ModelYear=2021, DailyPrice=400, Description="SEVEN SÜPERMARKET"},

            };
            _brands = new List<Brand> {

                new Brand{BrandId=1, BrandName="BMW"},
                new Brand{BrandId=2, BrandName="MERCEDES"},
                new Brand{BrandId=3, BrandName="PORSHE"},

            };
            _colors = new List<Color> { 
            
                new Color{ColorId=1, ColorName="BEYAZ"},
                new Color{ColorId=2, ColorName="SİYAH"},
                new Color{ColorId=3, ColorName="KIRMIZI"},

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(p => p.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(p=>p.ColorId==color.ColorId);
            _colors.Remove(colorToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId ==carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(p=>p.BrandId==brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }

        public void Update(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(p=>p.ColorId==color.ColorId);
            colorToDelete.ColorName = color.ColorName;

        }

        List<Brand> IBrandDal.GetAll()
        {
            return _brands;
        }

        List<Color> IColorDal.GetAll()
        {
            return _colors;
        }

        List<Brand> IBrandDal.GetById(int brandId)
        {
            return _brands.Where(p=>p.BrandId==brandId).ToList();
        }

        List<Color> IColorDal.GetById(int colorId)
        {
            return _colors.Where(p=>p.ColorId==colorId).ToList();
        }
    }
}
