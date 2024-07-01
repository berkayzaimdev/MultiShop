using MediatR;
using MultiShop.Order.Application.Features.Addresses.Commands.Common;
using MultiShop.Order.Application.Features.Addresses.Commands.Create;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Addresses.Commands.Update
{
    public class UpdateAddressCommand : AddressCommand, IRequest
    {
        public int Id { get; set; }

        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
        {
            private readonly IRepository<Address> _repository;

            public UpdateAddressCommandHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                value.City = request.City;
                value.Detail = request.Detail;
                value.District = request.District;
                value.UserId = request.UserId;
                await _repository.UpdateAsync(value);
            }
        }
    }
}
