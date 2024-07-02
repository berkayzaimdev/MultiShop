using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderDetails.Commands.Delete
{
    public class DeleteOrderDetailCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderDetailCommand(int id)
        {
            Id = id;
        }

        public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand>
        {
            private readonly IRepository<OrderDetail> _repository;

            public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                await _repository.DeleteAsync(value);
            }
        }
    }
}
