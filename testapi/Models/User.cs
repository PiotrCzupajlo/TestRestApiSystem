using Microsoft.EntityFrameworkCore;

namespace testapi.Models
{


    [PrimaryKey(nameof(ID))]
    public class User
    {
    
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
