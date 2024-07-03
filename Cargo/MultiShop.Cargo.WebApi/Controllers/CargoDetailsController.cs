using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetails;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _service;

        public CargoDetailsController(ICargoDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var details = _service.TGetAll();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var detail = _service.TGetById(id);
            if (detail == null)
            {
                return NotFound();
            }
            return Ok(detail);
        }

        [HttpPost]
        public IActionResult Create(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail detail = new()
            {
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId
            };
            _service.TInsert(detail);
            return Ok("Kargo detayı başarıyla oluşturuldu!");
        }

        [HttpPut("{id}")]
        public IActionResult Update(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail detail = new()
            {
                Id = updateCargoDetailDto.Id,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId
            };
            _service.TUpdate(detail);
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
