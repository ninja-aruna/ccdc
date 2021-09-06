using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IStructureRepositoryAsync : IGenericRepositoryAsync<Structure>
    {
        Task<bool> IsUniqueStructureAsync(string url);
    }
}
