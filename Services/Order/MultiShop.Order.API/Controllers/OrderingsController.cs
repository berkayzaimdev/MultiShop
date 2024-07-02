using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Orderings.Commands.Create;
using MultiShop.Order.Application.Features.Orderings.Commands.Delete;
using MultiShop.Order.Application.Features.Orderings.Commands.Update;
using MultiShop.Order.Application.Features.Orderings.Queries.GetAll;
using MultiShop.Order.Application.Features.Orderings.Queries.GetById;

namespace MultiShop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderingsAsync()
        {
            var orderings = await _mediator.Send(new GetAllOrderingsQuery());
            return Ok(orderings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingByIdAsync(int id)
        {
            var ordering = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(ordering);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderingAsync(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderingAsync(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderingAsync(int id)
        {
            await _mediator.Send(new DeleteOrderingCommand(id));
            return NoContent();
        }
    }
}
