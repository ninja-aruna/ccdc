using Domain.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptOut)]
    public class Structure : AuditableBaseEntity
    {
        [NotMapped]
        [JsonProperty]
        public StructureAttribute Attributes { get; set; }
    }
}
