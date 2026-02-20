using System.Text.Json.Serialization;
namespace testapi.Models
{
    public class JSONChange
    {
        [JsonPropertyName("Table")]
        public string Table { get; set; }
        [JsonPropertyName("Currency")]
        public string Currency { get; set; }
        [JsonPropertyName("Code")]
        public string Code { get; set; }
        [JsonPropertyName("Rates")]
        public List<JSONrate> Rates { get; set; }
    }
}
