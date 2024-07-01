using MediatR;
using MultiShop.Order.Application.Features.Addresses.Queries.Common;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Addresses.Queries.GetAll
{
    public class GetAllAddressesQuery : IRequest<IEnumerable<AddressResponse>>
    {
        public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressResponse>>
        {
            private readonly IRepository<Address> _repository;

            public GetAllAddressesQueryHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<AddressResponse>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.GetAllAsync();
                return values.Select(x => new AddressResponse
                {
                    Id = x.Id,
                    City = x.City,
                    Detail = x.Detail,
                    District = x.District,
                    UserId = x.UserId
                });
            }
        }
    }
}
