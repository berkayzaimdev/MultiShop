using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperations;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _service;

        public CargoOperationsController(ICargoOperationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var operations = _service.TGetAll();
            return Ok(operations);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var operation = _service.TGetById(id);
            if (operation == null)
            {
                return NotFound();
            }
            return Ok(operation);
        }

        [HttpPost]
        public IActionResult Create(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation operation = new()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            };
            _service.TInsert(operation);
            return Ok("Kargo operasyonu başarıyla oluşturuldu!");
        }

        [HttpPut("{id}")]
        public IActionResult Update(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation operation = new()
            {
                Id = updateCargoOperationDto.Id,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _service.TUpdate(operation);
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
