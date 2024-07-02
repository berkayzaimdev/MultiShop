using MediatR;
using MultiShop.Order.Application.Features.Orderings.Commands.Common;
using MultiShop.Order.Application.Features.Orderings.Commands.Update;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Orderings.Commands.Create
{
    public class CreateOrderingCommand : OrderingCommand, IRequest
    {
        public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
        {
            private readonly IRepository<Ordering> _repository;

            public CreateOrderingCommandHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new Ordering {
                    OrderDate = request.OrderDate,
                    TotalPrice = request.TotalPrice,
                    UserId = request.UserId
                });
            }
        }
    }
}
