using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptOut)]
    [Serializable]
    public class StructureAttribute
    {
        public string PublicationYear { get; set; }
        public string Publisher { get; set; }
        public IEnumerable<Title> Titles { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public string Url { get; set; }

    }
}