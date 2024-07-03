using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomers;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _service;

        public CargoCustomersController(ICargoCustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _service.TGetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _service.TGetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer customer = new()
            {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Address = createCargoCustomerDto.Address,
                Email = createCargoCustomerDto.Email,
                District = createCargoCustomerDto.District,
                City = createCargoCustomerDto.City,
                Phone = createCargoCustomerDto.Phone,
            };
            _service.TInsert(customer);
            return Ok("Kargo müşterisi başarıyla oluşturuldu!");
        }

        [HttpPut("{id}")]
        public IActionResult Update(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer customer = new()
            {
                Id = updateCargoCustomerDto.Id,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Address = updateCargoCustomerDto.Address,
                Email = updateCargoCustomerDto.Email,
                District = updateCargoCustomerDto.District,
                City = updateCargoCustomerDto.City,
                Phone = updateCargoCustomerDto.Phone
            };
            _service.TUpdate(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return NoContent();
        }
    }

}
