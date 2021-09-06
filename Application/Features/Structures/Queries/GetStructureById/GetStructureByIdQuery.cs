using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Structures.Queries.GetStructureById
{
    public class GetStructureByIdQuery : IRequest<Response<Structure>>
    {
        public int Id { get; set; }
        public class GetStructureByIdQueryHandler : IRequestHandler<GetStructureByIdQuery, Response<Structure>>
        {
            private readonly IStructureRepositoryAsync _structureRepository;
            public GetStructureByIdQueryHandler(IStructureRepositoryAsync structureRepository)
            {
                _structureRepository = structureRepository;
            }
            public async Task<Response<Structure>> Handle(GetStructureByIdQuery query, CancellationToken cancellationToken)
            {
                var structure = await _structureRepository.GetByIdAsync(query.Id);
                if (structure == null) throw new ApiException($"Structure Not Found.");
                return new Response<Structure>(structure);
            }
        }
    }
}
