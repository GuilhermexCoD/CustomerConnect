using System.ComponentModel.DataAnnotations;

namespace CustomerConnect.Application.Dtos
{
    public class ClientDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<PhoneDto> Phones { get; set; }
    }
}
