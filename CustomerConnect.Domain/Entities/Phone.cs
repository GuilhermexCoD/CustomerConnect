
namespace CustomerConnect.Domain.Entities
{
    public class Phone : Entity
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public string Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}
