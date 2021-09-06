using Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application.Features.Structures.Queries.GetAllStructures
{
    public class GetAllStructuresViewModel
    {
        public string Id { get; set; }
        public StructureAttribute Attributes { get; set; }

    }
}
