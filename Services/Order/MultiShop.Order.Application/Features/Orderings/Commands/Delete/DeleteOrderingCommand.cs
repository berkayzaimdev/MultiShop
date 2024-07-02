using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MultiShop.Order.Application.Features.Orderings.Commands.Delete
{
    public class DeleteOrderingCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderingCommand(int id)
        {
            Id = id;
        }

        public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
        {
            private readonly IRepository<Ordering> _repository;

            public DeleteOrderingCommandHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                await _repository.DeleteAsync(value);
            }
        }
    }
}
