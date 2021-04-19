using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
       

        public BrandManager(IBrandDal brandDal)
        {
           
            _brandDal = brandDal;
           
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length>2)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("brand name 2 karakterden az olamaz..");
            }
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<List<Brand>> GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p=>p.BrandId==brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
