using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class StructureRepositoryAsync : GenericRepositoryAsync<Structure>, IStructureRepositoryAsync
    {
        private readonly DbSet<Structure> _structures;

        public StructureRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _structures = dbContext.Set<Structure>();
        }

        public Task<bool> IsUniqueStructureAsync(string id)
        {
            return _structures
                .AllAsync(p => p.Id != id);
        }
    }
}
