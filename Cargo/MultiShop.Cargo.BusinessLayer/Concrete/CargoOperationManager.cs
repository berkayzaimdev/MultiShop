using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _dal;

        public CargoOperationManager(ICargoOperationDal dal)
        {
            _dal = dal;
        }

        public void TInsert(CargoOperation entity)
        {
            _dal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _dal.Update(entity);
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public CargoOperation TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<CargoOperation> TGetAll()
        {
            return _dal.GetAll();
        }
    }
}
