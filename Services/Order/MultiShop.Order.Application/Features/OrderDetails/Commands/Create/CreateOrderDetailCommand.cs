using MediatR;
using MultiShop.Order.Application.Features.OrderDetails.Commands.Common;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderDetails.Commands.Create
{
    public class CreateOrderDetailCommand : OrderDetailCommand, IRequest
    {
        public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand>
        {
            private readonly IRepository<OrderDetail> _repository;

            public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new OrderDetail 
                {
                    OrderingId = request.OrderingId,
                    ProductId = request.ProductId,
                    ProductName = request.ProductName,
                    ProductAmount = request.ProductAmount,
                    ProductPrice = request.ProductPrice,
                    ProductTotalPrice = request.ProductTotalPrice,
                });
            }
        }
    }
}
