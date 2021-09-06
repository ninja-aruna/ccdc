using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Subject
    {
        [JsonProperty(PropertyName = "subject")]
        public string SubjectName { get; set; }
    }
}