using MediatR;
using MultiShop.Order.Application.Features.Addresses.Queries.Common;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Addresses.Queries.GetById
{
    public class GetAddressByIdQuery : IRequest<AddressResponse>
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }

        public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressResponse>
        {
            private readonly IRepository<Address> _repository;

            public GetAddressByIdQueryHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task<AddressResponse> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                return new AddressResponse 
                {
                    Id = request.Id,
                    City = value.City,
                    Detail = value.Detail,
                    District = value.District,
                    UserId = value.UserId
                };
            }
        }
    }
}
