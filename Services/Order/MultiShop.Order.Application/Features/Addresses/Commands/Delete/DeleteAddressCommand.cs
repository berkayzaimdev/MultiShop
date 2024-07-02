using MediatR;
using MultiShop.Order.Application.Features.Addresses.Commands.Common;
using MultiShop.Order.Application.Features.Addresses.Commands.Update;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Addresses.Commands.Delete
{
    public class DeleteAddressCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteAddressCommand(int id)
        {
            Id = id;
        }

        public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
        {
            private readonly IRepository<Address> _repository;

            public DeleteAddressCommandHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }
            public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                await _repository.DeleteAsync(value);
            }
        }
    }
}
