using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
        }
    }
}
