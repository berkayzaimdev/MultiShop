using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.OrderDetails.Commands.Create;
using MultiShop.Order.Application.Features.OrderDetails.Commands.Delete;
using MultiShop.Order.Application.Features.OrderDetails.Commands.Update;
using MultiShop.Order.Application.Features.OrderDetails.Queries.GetAll;
using MultiShop.Order.Application.Features.OrderDetails.Queries.GetById;

namespace MultiShop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var orders = await _mediator.Send(new GetAllOrderDetailsQuery());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var order = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(UpdateOrderDetailCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            await _mediator.Send(new DeleteOrderDetailCommand (id));
            return NoContent();
        }
    }
}
