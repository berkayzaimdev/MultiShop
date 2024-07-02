using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Addresses.Commands.Create;
using MultiShop.Order.Application.Features.Addresses.Commands.Delete;
using MultiShop.Order.Application.Features.Addresses.Commands.Update;
using MultiShop.Order.Application.Features.Addresses.Queries.GetAll;
using MultiShop.Order.Application.Features.Addresses.Queries.GetById;

namespace MultiShop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressesAsync()
        {
            var addresses = await _mediator.Send(new GetAllAddressesQuery());
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressByIdAsync(int id)
        {
            var address = await _mediator.Send(new GetAddressByIdQuery(id));
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddressAsync(CreateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddressAsync(int id, UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressAsync(int id)
        {
            await _mediator.Send(new DeleteAddressCommand(id));
            return NoContent();
        }
    }
}
