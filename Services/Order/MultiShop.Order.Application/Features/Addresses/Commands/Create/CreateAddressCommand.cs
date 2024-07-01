using MediatR;
using MultiShop.Order.Application.Features.Addresses.Commands.Common;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Addresses.Commands.Create
{
    public class CreateAddressCommand : AddressCommand, IRequest
    {
        public int Id { get; set; }

        public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
        {
            private readonly IRepository<Address> _repository;

            public CreateAddressCommandHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new Address 
                {
                    City = request.City,
                    Detail = request.Detail,
                    District = request.District,
                    UserId = request.UserId
                });
            }
        }
    }
}
