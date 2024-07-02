using MediatR;
using MultiShop.Order.Application.Features.OrderDetails.Queries.Common;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderDetails.Queries.GetById
{
    public class GetOrderDetailByIdQuery : IRequest<OrderDetailResponse>
    {
        public int Id { get; set; }

        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }

        public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, OrderDetailResponse>
        {
            private readonly IRepository<OrderDetail> _repository;

            public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task<OrderDetailResponse> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                return new OrderDetailResponse
                {
                    Id = value.Id,
                    ProductId = value.ProductId,
                    OrderingId = value.OrderingId,
                    ProductAmount = value.ProductAmount,
                    ProductName = value.ProductName,
                    ProductPrice = value.ProductPrice,
                    ProductTotalPrice = value.ProductTotalPrice
                };
            }
        }
    }
}
