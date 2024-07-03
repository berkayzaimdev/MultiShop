using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _dal;

        public CargoCompanyManager(ICargoCompanyDal dal)
        {
            _dal = dal;
        }

        public void TInsert(CargoCompany entity)
        {
            _dal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _dal.Update(entity);
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public CargoCompany TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<CargoCompany> TGetAll()
        {
            return _dal.GetAll();
        }
    }
}
