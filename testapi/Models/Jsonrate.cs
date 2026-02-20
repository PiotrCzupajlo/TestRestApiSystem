using System.Text.Json.Serialization;

namespace testapi.Models
{
    public class JSONrate
    {
        [JsonPropertyName("No")]
        public string No { get; set; }
        [JsonPropertyName("EffectiveDate")]
        public string EffectiveDate { get; set; }
        [JsonPropertyName("mid")]
        public decimal mid { get; set; }
    }
}
