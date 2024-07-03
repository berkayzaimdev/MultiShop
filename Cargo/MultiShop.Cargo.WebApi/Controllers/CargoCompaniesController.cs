using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanies;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _service;

        public CargoCompaniesController(ICargoCompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _service.TGetAll();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _service.TGetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public IActionResult Create(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany company = new()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
            };
            _service.TInsert(company);
            return Ok("Kargo şirketi başarıyla oluşturuldu!");
        }

        [HttpPut("{id}")]
        public IActionResult Update(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany company = new()
            {
                Id = updateCargoCompanyDto.Id,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            _service.TUpdate(company);
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
