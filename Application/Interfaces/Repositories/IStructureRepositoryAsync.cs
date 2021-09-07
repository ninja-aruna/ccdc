using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IStructureRepositoryAsync : IGenericRepositoryAsync<Structure>
    {
        Task<bool> IsUniqueStructureAsync(string url);
        Task<IReadOnlyList<Structure>> GetPagedReponseAsync(int pageNumber, int pageSize);

    }
}
