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

    }
}
