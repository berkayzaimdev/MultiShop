using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
        }
    }
}
