using MediatR;
using MultiShop.Order.Application.Features.Orderings.Queries.Common;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Orderings.Queries.GetById
{
    public class GetOrderingByIdQuery : IRequest<OrderingResponse>
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }

        public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, OrderingResponse>
        {
            private readonly IRepository<Ordering> _repository;

            public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task<OrderingResponse> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                return new OrderingResponse
                {
                    Id = value.Id,
                    OrderDate = value.OrderDate,
                    TotalPrice = value.TotalPrice,
                    UserId = value.UserId
                };
            }
        }
    }
}
