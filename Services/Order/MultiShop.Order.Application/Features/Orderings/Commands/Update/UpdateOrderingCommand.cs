using MediatR;
using MultiShop.Order.Application.Features.Orderings.Commands.Common;
using MultiShop.Order.Application.Features.Orderings.Commands.Delete;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Orderings.Commands.Update
{
    public class UpdateOrderingCommand : OrderingCommand, IRequest
    {
        public int Id { get; set; }

        public UpdateOrderingCommand(int id)
        {
            Id = id;
        }

        public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
        {
            private readonly IRepository<Ordering> _repository;

            public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                value.OrderDate = request.OrderDate;
                value.TotalPrice = request.TotalPrice;
                value.UserId = request.UserId;
                await _repository.UpdateAsync(value);
            }
        }
    }
}
