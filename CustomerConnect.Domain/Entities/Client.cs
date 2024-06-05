using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CustomerConnect.Domain.Entities
{
    public class Client : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<Phone> Phones { get; set; }

    }
}
