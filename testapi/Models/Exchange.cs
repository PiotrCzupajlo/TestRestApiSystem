using System.Text.Json;
using System.Text.Json.Serialization;
namespace testapi.Models
{
    public interface IExchange
    {
        Task<decimal> GetExchangeRate(string currency);
    }
    public class Exchange :IExchange
    {
        public Exchange() { 
        
        
        }
        public async Task<decimal> GetExchangeRate(string currency)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://api.nbp.pl/api/exchangerates/rates/a/{currency}");
                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<JSONChange>(content,options);
                    return data.Rates[0].mid;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
