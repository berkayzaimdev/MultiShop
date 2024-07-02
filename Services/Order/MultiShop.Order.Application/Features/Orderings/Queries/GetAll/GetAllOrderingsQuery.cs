using MediatR;
using MultiShop.Order.Application.Features.Orderings.Queries.Common;
using MultiShop.Order.Application.Features.Orderings.Queries.GetById;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Orderings.Queries.GetAll
{
    public class GetAllOrderingsQuery : IRequest<IEnumerable<OrderingResponse>>
    {
        public class GetAllOrderingsQueryHandler : IRequestHandler<GetAllOrderingsQuery, IEnumerable<OrderingResponse>>
        {
            private readonly IRepository<Ordering> _repository;

            public GetAllOrderingsQueryHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<OrderingResponse>> Handle(GetAllOrderingsQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.GetAllAsync();
                return values.Select(value => new OrderingResponse
                {
                    Id = value.Id,
                    OrderDate = value.OrderDate,
                    TotalPrice = value.TotalPrice,
                    UserId = value.UserId
                });
            }
        }
    }
}
