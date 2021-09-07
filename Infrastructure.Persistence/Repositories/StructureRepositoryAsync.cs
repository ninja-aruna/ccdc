using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Infrastructure.Persistence.Repositories
{
    public class StructureRepositoryAsync : GenericRepositoryAsync<Structure>, IStructureRepositoryAsync
    {
        private readonly DbSet<Structure> _structures;
        private static HttpClient _httpClient;


        public StructureRepositoryAsync(ApplicationDbContext dbContext, HttpClient httpClient = null) : base(dbContext)
        {
            _structures = dbContext.Set<Structure>();
            _httpClient = httpClient ?? new HttpClient();
        }

        public Task<bool> IsUniqueStructureAsync(string id)
        {
            return _structures
                .AllAsync(p => p.Id != id);
        }

        public async Task<IReadOnlyList<Structure>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.test.datacite.org/dois?query=prefix:10.5517")
            };

            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var jobject = JObject.Parse(responseBody);
            var structures = JsonConvert.DeserializeObject<IReadOnlyList<Structure>>(jobject["data"].ToString());
            return structures;
        }
    }
}
