using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2005,DailyPrice=36000,Description="Sunroof"},
                new Car{Id=2,BrandId=1,ColorId=3,ModelYear=2012,DailyPrice=66000,Description="İki Kapılı"},
                new Car{Id=3,BrandId=3,ColorId=2,ModelYear=2015,DailyPrice=89000,Description="Kangoo"},
                new Car{Id=4,BrandId=2,ColorId=5,ModelYear=2001,DailyPrice=59000,Description="V8 Motor"},
                new Car{Id=5,BrandId=3,ColorId=1,ModelYear=2000,DailyPrice=14000,Description="üüüüffff"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete=_cars.SingleOrDefault(c=>c.ModelYear==car.ModelYear);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAllCar()
        {
            return _cars;
        }

        public List<Car> GetCarsByBrand(int BrandId)
        {
            return _cars.Where(c=>c.BrandId==BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            carToUpdate= _cars.SingleOrDefault(c=>c.Id==car.Id); //gönderdipim ıdye sahip arabayı bul
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ModelYear=car.ModelYear;
            carToUpdate.Description=car.Description;
        }
    }
}
