using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Structures.Commands.DeleteStructureById
{
    public class DeleteStructureByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteStructureByIdCommandHandler : IRequestHandler<DeleteStructureByIdCommand, Response<int>>
        {
            private readonly IStructureRepositoryAsync _structureRepository;
            public DeleteStructureByIdCommandHandler(IStructureRepositoryAsync structureRepository)
            {
                _structureRepository = structureRepository;
            }
            public async Task<Response<int>> Handle(DeleteStructureByIdCommand command, CancellationToken cancellationToken)
            {
                var structure = await _structureRepository.GetByIdAsync(command.Id);
                if (structure == null) throw new ApiException($"Structure Not Found.");
                await _structureRepository.DeleteAsync(structure);
                return new Response<int>(structure.Id);
            }
        }
    }
}
