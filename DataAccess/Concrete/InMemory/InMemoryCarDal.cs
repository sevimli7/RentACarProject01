using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
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
            
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId ==carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
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

    }
}
