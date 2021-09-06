using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Structures.Commands.CreateStructure
{
    public partial class CreateStructureCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
    public class CreateStructureCommandHandler : IRequestHandler<CreateStructureCommand, Response<int>>
    {
        private readonly IStructureRepositoryAsync _structureRepository;
        private readonly IMapper _mapper;
        public CreateStructureCommandHandler(IStructureRepositoryAsync structureRepository, IMapper mapper)
        {
            _structureRepository = structureRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateStructureCommand request, CancellationToken cancellationToken)
        {
            var structure = _mapper.Map<Structure>(request);
            await _structureRepository.AddAsync(structure);
            return new Response<int>(structure.Id);
        }
    }
}
