using MediatR;
using MultiShop.Order.Application.Features.OrderDetails.Commands.Common;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderDetails.Commands.Update
{
    public class UpdateOrderDetailCommand : OrderDetailCommand, IRequest
    {
        public int Id { get; set; }

        public UpdateOrderDetailCommand(int id)
        {
            Id = id;
        }

        public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
        {
            private readonly IRepository<OrderDetail> _repository;

            public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                value.ProductName = request.ProductName;
                value.ProductPrice = request.ProductPrice;
                value.ProductTotalPrice = request.ProductTotalPrice;
                value.ProductAmount = request.ProductAmount;
                value.ProductId = request.ProductId;
                value.OrderingId = request.OrderingId;
                await _repository.UpdateAsync(value);
            }
        }
    }
}
