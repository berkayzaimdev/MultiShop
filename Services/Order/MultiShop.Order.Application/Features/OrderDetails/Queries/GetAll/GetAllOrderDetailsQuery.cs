using MediatR;
using MultiShop.Order.Application.Features.OrderDetails.Queries.Common;
using MultiShop.Order.Application.Features.OrderDetails.Queries.GetById;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderDetails.Queries.GetAll
{
    public class GetAllOrderDetailsQuery : IRequest<IEnumerable<OrderDetailResponse>>
    {
        public class GetOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQuery, IEnumerable<OrderDetailResponse>>
        {
            private readonly IRepository<OrderDetail> _repository;

            public GetOrderDetailsQueryHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<OrderDetailResponse>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.GetAllAsync();
                return values.Select(value => new OrderDetailResponse
                {
                    Id = value.Id,
                    ProductId = value.ProductId,
                    OrderingId = value.OrderingId,
                    ProductAmount = value.ProductAmount,
                    ProductName = value.ProductName,
                    ProductPrice = value.ProductPrice,
                    ProductTotalPrice = value.ProductTotalPrice
                });
            }
        }
    }
}
