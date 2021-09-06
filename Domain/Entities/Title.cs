using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Title
    {
        [JsonProperty(PropertyName = "title")]
        public string StructureTitle { get; set; }
    }
}