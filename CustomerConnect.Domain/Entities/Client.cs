using System.ComponentModel.DataAnnotations;

namespace CustomerConnect.Domain.Entities
{
    public class Client : Entity
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

    }
}
