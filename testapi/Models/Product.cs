using Microsoft.EntityFrameworkCore;

namespace testapi.Models
{
    [PrimaryKey(nameof(ID))]
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
    }
}
