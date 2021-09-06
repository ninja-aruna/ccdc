using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Structures.Commands.UpdateStructure
{
    public class UpdateStructureCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public class UpdateStructureCommandHandler : IRequestHandler<UpdateStructureCommand, Response<int>>
        {
            private readonly IStructureRepositoryAsync _structureRepository;
            public UpdateStructureCommandHandler(IStructureRepositoryAsync structureRepository)
            {
                _structureRepository = structureRepository;
            }
            public async Task<Response<int>> Handle(UpdateStructureCommand command, CancellationToken cancellationToken)
            {
                var structure = await _structureRepository.GetByIdAsync(command.Id);

                if (structure == null)
                {
                    throw new ApiException($"Structure Not Found.");
                }
                else
                {
                    await _structureRepository.UpdateAsync(structure);
                    return new Response<int>(structure.Id);
                }
            }
        }
    }
}
