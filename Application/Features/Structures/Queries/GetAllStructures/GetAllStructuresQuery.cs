using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Structures.Queries.GetAllStructures
{
    public class GetAllStructuresQuery : IRequest<PagedResponse<IEnumerable<GetAllStructuresViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllStructuresQueryHandler : IRequestHandler<GetAllStructuresQuery, PagedResponse<IEnumerable<GetAllStructuresViewModel>>>
    {
        private readonly IStructureRepositoryAsync _structureRepository;
        private readonly IMapper _mapper;
        public GetAllStructuresQueryHandler(IStructureRepositoryAsync structureRepository, IMapper mapper)
        {
            _structureRepository = structureRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllStructuresViewModel>>> Handle(GetAllStructuresQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllStructuresParameter>(request);
            var structures = await _structureRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var structureViewModel = _mapper.Map<IEnumerable<GetAllStructuresViewModel>>(structures);
            return new PagedResponse<IEnumerable<GetAllStructuresViewModel>>(structureViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
